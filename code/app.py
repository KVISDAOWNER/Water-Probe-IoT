import dash
import DAL
import dash_core_components as dcc
import dash_daq as daq
import dash_html_components as html
import plotly.graph_objs as go
from dash.dependencies import Input, Output, State

# Token valid for 50.000 request pr year.
mapbox_access_token = 'pk.eyJ1Ijoid2F0ZXJib2lzIiwiYSI6ImNrMmFkaDhmejBmcGUzb3AyaGFucDMybGwifQ.YfZyC53gGwkDdi0CfnuJZw'
# external_stylesheets = ['https://codepen.io/chriddyp/pen/bWLwgP.css']

app = dash.Dash("Water Bois")
app.title = 'Waterbois'


def construct_default_graph():
    data_dict = {"time": [0, 1, 2, 3, 4, 5, 6, 7, 8]}
    data = go.Scatter(
        x=list(data_dict["time"]),
        y=list(),
        name='Scatter',
        fill="tozeroy",
        fillcolor="#6897bb",
        mode='lines+markers'
    )
    graph = (html.Div(dcc.Graph(
        figure={'data': [data],
                'layout': go.Layout(xaxis=dict(range=[min(data_dict["time"]), max(data_dict["time"])]),
                                    yaxis=dict(range=[0, 10]),
                                    margin={'l': 50, 'r': 1, 't': 100, 'b': 50},
                                    title='{}'.format('None Selected'))}
    )))
    return graph


all_probes_names = DAL.get_names_of_things()


def create_defaultmap():
    fig = go.Figure(go.Scattermapbox(
        lat=DAL.get_latitudes(all_probes),
        lon=DAL.get_longitudes(all_probes),
        mode='markers',
        marker=go.scattermapbox.Marker(
            size=11,
            color='red'
        ),
        selected={
            'marker':
                {
                    'color': 'green'
                }
        },
        text=all_probes_names,
        hoverinfo='text'
    ))

    fig.update_layout(
        autosize=True,
        hovermode='closest',
        clickmode='event+select',
        margin=dict(l=40, r=10, t=10,b=10),
        mapbox=go.layout.Mapbox(
            accesstoken=mapbox_access_token,
            bearing=0,
            style='open-street-map',
            center=go.layout.mapbox.Center(
                lat=57.04,
                lon=9.935
            ),
            pitch=0,
            zoom=11
        ),
    )
    return fig


all_probes = DAL.get_things_objects()

defaultmap = create_defaultmap()

# these global variables are only initialized
# on page load, so only once. So no worry
# for it re-computing them each time a user performs an action.
default_graph = construct_default_graph()

# needed when using multipage website
app.config.suppress_callback_exceptions = True

app.layout = html.Div([
    dcc.Location(id='url', refresh=False),
    html.Div(id='page-content')
])

main_page = html.Div([
    html.Div([
        html.H2('Waterbois',
                style={'float': 'left', 'width': '100%'})]),
    html.Div([
        html.Div([
            dcc.Checklist(
                id='checklist',
                #options=[{'label': desc, 'value': name} for name, desc in zip(all_probes_names, DAL.get_descriptions(all_probes))],
                options=[{'label': name, 'value': name} for name in all_probes_names],
                labelStyle={'display': 'block'},
            )
        ], style={'float': 'left', 'width': '15%', 'height': '500px'}),

        html.Div([
            dcc.Graph(
                id='probeMap',
                figure=defaultmap)
        ], style={'float': 'left', 'width': '85%', 'height': '500px'}),
    ]),

    html.Div([
        html.Div([
            html.H4('Specify Interval', style={'textAlign': 'center', 'horinzontal-align': 'middle'}),
            html.H5('Start', style={'textAlign': 'center', 'horizontal-align': 'middle', 'width': '100%'}),
            html.Div(dcc.Input(
                id="start_date",
                type="text",
                placeholder="yyyy-mm-dd"
            ), style={'textAlign': 'center', 'horizontal-align': 'middle'}),
            html.H5('End', style={'textAlign': 'center', 'horizontal-align': 'middle', 'width': '100%'}),
            html.Div(dcc.Input(
                id="end_date",
                type="text",
                placeholder="yyyy-mm-dd"
            ), style={'textAlign': 'center', 'horizontal-align': 'middle'}),
            html.Button('Apply', id='date_button', style={'width': '100%', 'marginTop': 20}),
            html.Div(id='updateresponse', style={'textAlign': 'center', 'marginTop': 20})
        ]),
    ], style={'width': '15%', 'display': 'inline-block', 'vertical-align': 'top'}),

    html.Div([
        html.Div(id='graphs', children=default_graph),
        html.H4('Select data to diplay:'),
        html.Div([dcc.Dropdown(id='data-elements', )])
    ], style={'display': 'inline-block', 'width': '85%', 'marginBottom': 40}),
])

admin_page = html.Div([
    html.Div(dcc.Input(id="probeId", placeholder="Enter probe id", type="text"),
             style={'margin': 20}),
    html.Div(dcc.Input(id="lat", placeholder="Enter latitude", type="text"),
             style={'margin': 20}),
    html.Div(dcc.Input(id="lon", placeholder="Enter longitude", type="text"),
             style={'margin': 20}),
    html.Div(dcc.Input(id="description", placeholder="Enter decription of location", type="text"),
             style={'margin': 20}),
    html.Div(html.Button('Update location', id='upd_loc_btn'), style={'margin': 20}),
    html.Div(id='response')
], style={'width': '100%'})


@app.callback(
    Output('response', 'children'),
    [Input('upd_loc_btn', 'n_clicks')],
    [State('probeId', 'value'),
     State('lat', 'value'),
     State('lon', 'value'),
     State('description', 'value')]
)
def patch_probe_location(n_clicks, probe_id,
                          lat, lon, desc):
    return 'Input: Id: {} Lat: {} Lon: {} Desc: {}'.format(
        probe_id, lat, lon, desc)


@app.callback(Output('page-content', 'children'),
              [Input('url', 'pathname')])
def display_page(pathname):
    if pathname == '/admin':
        return admin_page
    else:
        return main_page


@app.callback(
    Output('data-elements', 'options'),
    [Input('checklist', 'value')])
def update_data_elements(selected_probes):
    if selected_probes is None:
        return [{'label': s, 'value': s}
                for s in []]
    else:
        # a list of datastreams which is also a list
        list_of_datastreams = DAL.get_datastreams_of_things(selected_probes)
        elements = []
        for datastreams in list_of_datastreams:
            for datastream in datastreams:
                elements.append(datastream['name'])
        return [{'label': s, 'value': s}
                for s in elements]


def construct_data_dict(observations, data_name):
    data_dict = {}
    time = []
    data = []
    for observation in observations:
        for x in observation:
            time.append(x['resultTime'][:10])
            data.append(x['result'])

    data_dict['time'] = time
    data_dict[data_name] = data
    return data_dict


@app.callback(
    Output('checklist', 'value'),
    [Input('probeMap', 'selectedData')])
def update_checklist(selected_data):
    if selected_data is None:
        selected_points = []
    else:
        points = selected_data['points']
        selected_points = []
        for point in points:
            selected_points.append(point['text'])
    return selected_points


@app.callback(
    Output('probeMap', 'figure'),
    [Input('checklist', 'value')])
def update_map(value):
    if not value:
        return defaultmap
    else:
        selected_probes = []
        for i in range(len(value)):
            for j in range(len(all_probes)):
                if value[i] == all_probes[j].name:
                    selected_probes.append(j)

        fig = go.Figure(go.Scattermapbox(
            lat=DAL.get_latitudes(all_probes),
            lon=DAL.get_longitudes(all_probes),
            selectedpoints=selected_probes,
            mode='markers',
            marker=go.scattermapbox.Marker(
                size=11,
                color='red'
            ),
            selected={
                'marker':
                    {
                        'color':'green'
                    }
            },
            text=all_probes_names,
            hoverinfo='text'
        ))

        fig.update_layout(
            autosize=True,
            hovermode='closest',
            clickmode='event+select',
            margin=dict(l=40, r=10, t=10, b=10),
            mapbox=go.layout.Mapbox(
                accesstoken=mapbox_access_token,
                bearing=0,
                style='open-street-map',
                center=go.layout.mapbox.Center(
                    lat=57.04,
                    lon=9.935
                ),
                pitch=0,
                zoom=11
            ),
        )
        return fig


@app.callback(
    [Output('graphs', 'children'),
     Output('updateresponse', 'children')],
    [Input('data-elements', 'value'),
     Input('checklist', 'value'),
     Input('date_button', 'n_clicks')],
    [State('start_date', 'value'),
     State('end_date', 'value')])
def update_graph_data(datastream_name, selected_probes, n_clicks, start_date, end_date):
    response = ""

    # default graph, when nothing is selected.
    if not datastream_name:
        # med det andet output så bliver denne function ikke kaldt initially.
        # så var nødt til at gøre sådan, at default grafen var hardcoded til at starte
        # med, da ellers ville det ikke være nogen graf i starten. Men det er også
        # bedre, da den kun bliver kaldt ved page-load og ikke hvergang brugeren
        # gør noget, hvilket denne funktion gør.
        return default_graph, " "
    else:
        observations = DAL.get_observations_of_datastreams([datastream_name])
        data_dict = construct_data_dict(observations, datastream_name)
        y_min = min(data_dict[datastream_name])
        y_max = max(data_dict[datastream_name])
        x_min = min(data_dict["time"])
        x_max = max(data_dict["time"])
        if start_date is not None and \
                end_date is not None:
            if start_date > end_date:
                response = "Start date must be before end date."
            else:
                x_min = start_date
                x_max = end_date
                response = "Applied time interval to graph."

        data = (go.Scatter(
            x=list(data_dict["time"]),
            y=list(data_dict[datastream_name]),
            name=datastream_name,
            mode="lines+markers",
            fillcolor="#6897bb"
        ))

        graph = (html.Div(dcc.Graph(
            figure={'data': [data], 'layout': go.Layout(xaxis=dict(range=[x_min, x_max]),
                                                        yaxis=dict(range=[y_min - (y_min / 10), y_max + (y_max / 10)]),
                                                        margin={'l': 50, 'r': 1, 't': 100, 'b': 50},
                                                        title='Measurement: {}'.format(datastream_name))
                    }
        )))

        return graph, response


if __name__ == '__main__':
    app.run_server(debug=True)
