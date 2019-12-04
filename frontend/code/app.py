import dash
import api_helper as api
import dash_core_components as dcc
import dash_html_components as html
import plotly.graph_objs as go
import re
from dash.dependencies import Input, Output, State

# Token valid for 50.000 request pr year.
mapbox_access_token = 'pk.eyJ1Ijoid2F0ZXJib2lzIiwiYSI6ImNrM2lna3B5cTA1YnYza3Q1ZGJwMHloZHUifQ.CpKwtHYASGSCYDwnZAmepA'
app = dash.Dash("Water Bois")
app.title = 'Waterbois'
server = app.server


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
    graph = {'data': [data], 'layout': go.Layout(
        xaxis=dict(range=[min(data_dict["time"]), max(data_dict["time"])]),
        yaxis=dict(range=[0, 10]),
        margin={'l': 50, 'r': 10, 't': 50, 'b': 100})
             }

    return graph


def create_emptymap():
    fig = go.Figure(go.Scattermapbox())

    fig.update_layout(
        autosize=True,
        margin=dict(l=10, r=10, t=10, b=10),
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


def create_defaultmap(lats, lons, names):
    fig = go.Figure(go.Scattermapbox(
        lat=lats,
        lon=lons,
        mode='markers',
        marker=go.scattermapbox.Marker(
            size=9,
            color='red'
        ),
        selected={
            'marker':
                {
                    'color': 'green'
                }
        },
        text=names
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


# needed when using multipage website
app.config.suppress_callback_exceptions = True

app.layout = html.Div([
    dcc.Location(id='url', refresh=False),
    html.Div(id='page-content')
])

# these variables are just so callbacks
# have variables to use, since they
# aren't easily given as parameters to them.
all_probes_names = api.get_names_of_things()
all_probes = api.get_things_objects()
lats = api.get_latitudes(all_probes)
lons = api.get_longitudes(all_probes)

defaultmap = create_defaultmap(lats, lons, all_probes_names)
default_graph = construct_default_graph()
emptymap = create_emptymap()


# this function is called on pageloads.
def create_main_page():
    # so we make sure we have all the new information from the database.
    global all_probes_names, all_probes, lats, lons, defaultmap, default_graph

    all_probes_names = api.get_names_of_things()
    all_probes = api.get_things_objects()
    lats = api.get_latitudes(all_probes)
    lons = api.get_longitudes(all_probes)

    defaultmap = create_defaultmap(lats, lons, all_probes_names)
    default_graph = construct_default_graph()
    return html.Div([
        html.Div([
            html.H2('Waterbois',
                    style={'float': 'left', 'width': '100%'})]),
        html.Div([
            html.Div([
                dcc.Checklist(
                    id='checklist',
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
                html.H3('Select data to diplay', style={'textAlign': 'center', 'horizontal-align': 'middle',
                                                        'font-family': 'Helvetica'}),
                html.Div([dcc.Dropdown(id='data-elements', placeholder="Select measurement", )]),
                html.H4('Specify Interval',
                        style={'textAlign': 'center', 'horinzontal-align': 'middle', 'marginTop': 20,
                               'font-family': 'Helvetica'}),
                html.H5('Start', style={'textAlign': 'center', 'horizontal-align': 'middle', 'width': '100%',
                                        'font-family': 'Helvetica'}),
                html.Div(dcc.Input(
                    id="start_date",
                    type="text",
                    placeholder="yyyy-mm-dd-hh:mm:ss",
                    style={'padding': '10px', 'border-radius': '4px', 'border': '1px solid #bbb'}
                ), style={'textAlign': 'center', 'horizontal-align': 'middle'}),
                html.H5('End',
                        style={'textAlign': 'center', 'horizontal-align': 'middle', 'marginTop': 15, 'width': '100%',
                               'font-family': 'Helvetica'}),
                html.Div(dcc.Input(
                    id="end_date",
                    type="text",
                    placeholder="yyyy-mm-dd-hh:mm:ss",
                    style={'padding': '10px', 'border-radius': '4px', 'border': '1px solid #bbb'}
                ), style={'textAlign': 'center', 'horizontal-align': 'middle'}),
                html.Button('Apply', id='date_button', style={'width': '100%', 'marginTop': 15,
                                                              'padding': '10px', 'background-color': '#FFF',
                                                              'border-radius': '4px', 'border': '1px solid #bbb'}),
                html.Div(id='updateresponse',
                         style={'textAlign': 'center', 'marginTop': 20, 'font-family': 'Helvetica'})
            ]),
        ], style={'width': '15%', 'display': 'inline-block', 'vertical-align': 'top'}),

        html.Div([
            dcc.Graph(id='graph', figure=default_graph)
        ], style={'display': 'inline-block', 'width': '85%', 'marginBottom': 40}),
    ], style={'marginLeft': 10})


# this function is called on pageloads.
def create_admin_page():
    return html.Div([
        html.Div([
            html.H3('Update location of probe', style={'width': '100%', 'horizontal-align': 'middle',
                                                       'font-family': 'Helvetica'}),
            html.Div(dcc.Input(id="probeId", placeholder="Enter probe id", type="text",
                               style={'width': '100%', 'padding': '10px', 'border-radius': '4px',
                                      'border': '1px solid #bbb'})),
            html.Div(dcc.Input(id="lat", placeholder="Enter latitude", type="text",
                               style={'width': '100%', 'marginTop': 20, 'padding': '10px', 'border-radius': '4px',
                                      'border': '1px solid #bbb'})),
            html.Div(dcc.Input(id="lon", placeholder="Enter longitude", type="text",
                               style={'width': '100%', 'marginTop': 20, 'padding': '10px', 'border-radius': '4px',
                                      'border': '1px solid #bbb'})),
            html.Div(dcc.Input(id="description", placeholder="Enter description of location", type="text",
                               style={'width': '100%', 'marginTop': 20, 'padding': '10px', 'border-radius': '4px',
                                      'border': '1px solid #bbb'})),
            html.Div(
                html.Button('Update location', id='upd_loc_btn',
                            style={'width': '100%', 'marginTop': 15, 'marginLeft': 10,
                                   'padding': '10px', 'background-color': '#FFF',
                                   'border-radius': '4px',
                                   'border': '1px solid #bbb'})),
            html.Div(id='response', style={'marginTop': 20, 'font-family': 'Helvetica'})
        ], style={'width': '20%', 'float': 'left', 'marginRight': 30}),

        html.Div(dcc.Graph(id='empty_graph', figure=emptymap), style={'marginTop': 15, 'width': '75%', 'float': 'left'})
    ], style={'marginLeft': 20})


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
    if n_clicks is None:
        return " "

    pos_names = api.get_names_of_things()
    if probe_id not in pos_names:
        return "Invalid probe id."

    if not is_number(lat) or not is_number(lon):
        return "Latitude and Longitude must be numbers."

    if is_number(lat) and is_number(lon):
        if not (-90 <= float(lat) <= 90) or not (-180 <= float(lon) <= 180):
            return "Latitude or Longitude is out of range."

    success = api.patch_location_of_thing(probe_id, lat, lon, desc)
    if success:
        return "Probe: {} was updated.".format(probe_id)
    else:
        return "Something went wrong."


def is_number(s):
    try:
        float(s)
        success = True
    except ValueError:
        success = False
    return success


@app.callback(Output('page-content', 'children'),
              [Input('url', 'pathname')])
def display_page(pathname):
    # called on pageloads. Thus always
    # reading the potentially new data from database.
    if pathname == '/admin':
        return create_admin_page()
    else:
        return create_main_page()


@app.callback(
    Output('data-elements', 'options'),
    [Input('checklist', 'value')])
def update_data_elements(selected_probes):
    if selected_probes is None:
        return [{'label': s, 'value': s}
                for s in []]
    else:
        # a list of datastreams which is also a list
        list_of_datastreams = api.get_datastreams_of_things(selected_probes)
        # the names of the probes associated to each datastream.
        probe_names = []
        datastream_names = []
        descriptions = []
        for datastreams in list_of_datastreams:
            for datastream in datastreams:
                probe_names.append(datastream['name'].split('_')[-1])
                datastream_names.append(datastream['name'])
                descriptions.append(datastream['description'])

        zipped = zip(datastream_names, descriptions, probe_names)
        return [{'label': pname + ' - ' + desc, 'value': dname}
                for dname, desc, pname in zipped]


def construct_data_dict(observations, data_name):
    data_dict = {}
    time = []
    data = []
    for observation in observations:
        for x in observation:
            temp_time = x['resultTime'][:19]
            day = temp_time[:10]
            hour = temp_time[11:19]
            total = day + '-' + hour
            time.append(total)
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
        # We only have one dataset in our figure.
        # Therefore we access index 0.
        defaultmap.data[0].selectedpoints = []
        return defaultmap
    else:
        selected_probes = []
        for i in range(len(value)):
            for j in range(len(all_probes)):
                if value[i] == all_probes[j].name:
                    selected_probes.append(j)
        defaultmap.data[0].selectedpoints = selected_probes
        return defaultmap


def correct_format(date):
    date_pattern = re.compile(r"\d\d\d\d-\d\d-\d\d-\d\d:\d\d:\d\d")
    return date_pattern.match(date) is not None


@app.callback(
    [Output('graph', 'figure'),
     Output('updateresponse', 'children')],
    [Input('data-elements', 'value'),
     Input('date_button', 'n_clicks')],
    [State('start_date', 'value'),
     State('end_date', 'value')])
def update_graph_data(datastream_name, n_clicks, start_date, end_date):
    response = ""

    # default graph, when nothing is selected.
    if not datastream_name:
        return default_graph, response
    else:
        observations = api.get_observations_of_datastreams([datastream_name])
        data_dict = construct_data_dict(observations, datastream_name)

        if start_date is not None and \
                end_date is not None:
            if not correct_format(start_date) or not correct_format(end_date):
                response = "Either start date or end date is on wrong format."
            elif start_date > end_date:
                response = "Start date must be before end date."
            elif start_date < data_dict["time"][0] or \
                    end_date > data_dict["time"][-1]:
                response = "Interval is out of bounds."
            else:
                new_times = []
                new_values = []
                zipped = zip(data_dict["time"], data_dict[datastream_name])
                for time, value in zipped:
                    if time >= end_date:
                        break
                    elif time >= start_date:
                        new_times.append(time)
                        new_values.append(value)
                data_dict["time"] = new_times
                data_dict[datastream_name] = new_values
                response = "Applied time interval to graph."

        y_min = min(data_dict[datastream_name])
        y_max = max(data_dict[datastream_name])
        x_min = min(data_dict["time"])
        x_max = max(data_dict["time"])

        data = (go.Scatter(
            x=list(data_dict["time"]),
            y=list(data_dict[datastream_name]),
            name=datastream_name,
            mode="lines+markers",
            fillcolor="#6897bb"
        ))

        graph = {'data': [data], 'layout': go.Layout(
            xaxis=dict(range=[x_min, x_max]),
            yaxis=dict(range=[y_min - (y_min / 10), y_max + (y_max / 10)]),
            margin={'l': 50, 'r': 10, 't': 50, 'b': 100})
                 }

        return graph, response


if __name__ == '__main__':
    app.run_server(debug=True)
