import dash
import dash_core_components as dcc
import dash_html_components as html
import plotly.graph_objs as go
from dash.dependencies import Input, Output, State
import DAL

#Token valid for 50.000 request pr year.
mapbox_access_token = 'pk.eyJ1Ijoid2F0ZXJib2lzIiwiYSI6ImNrMmFkaDhmejBmcGUzb3AyaGFucDMybGwifQ.YfZyC53gGwkDdi0CfnuJZw'
#external_stylesheets = ['https://codepen.io/chriddyp/pen/bWLwgP.css']

app = dash.Dash("Water Bois")
server = app.server
#name = DAL.get_id_of_things()
#probelist = {
#    'Probe #1': '001',
#    'Probe #2': '002',
#    'Probe #3': '003',
#    'Probe #4': '004',
#    'Probe #5': '005',
#    'Probe #6': '006',
#    'Probe #7': '007',
#    'Probe #8': '008'
#}



#probes = [{'label': name, 'value': name} for name in probelist ]

'''styles = {
    'pre': {
        'border': 'thin lightgrey solid',
        'overflowX': 'scroll'
    }
}'''

fig = go.Figure(go.Scattermapbox(
    lat=['57.045249', '57.040299', '57.042354', '57.021803',
         '57.036190', '57.043941', '57.015982', '57.016917'],
    lon=['9.862715', '9.859284', '9.880389', '9.919854',
         '9.922599', '9.941473', '9.985465', '10.003408'],
    mode='markers',
    marker=go.scattermapbox.Marker(
        size=11,
        color='red'
    ),
    #text=["Probe #1", "Probe #2", "Probe #3", "Probe #4",
     #     "Probe #5", "Probe #6", "Probe #7", "Probe #8"],
))

fig.update_layout(
    autosize=True,
    hovermode='closest',
    clickmode='event+select',
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

app.layout = html.Div([
#    dcc.Checklist(
#        id='checklist',
#        options=probes,
#    ),

    dcc.Graph(
        id='probeMap',
        figure=fig,
        style={'height': '700px', 'width': '700px'}
    ),

#    html.Div([
#        html.Pre(id='selected-data', style=styles['pre'])
#    ])
])

#@app.callback(
#    Output('selected-data','children'),
#def display_checklist(value):
 #   return json.dumps(value, indent=2)


#@app.callback(
#    Output('selected-data', 'children'),
#    [Input('probeMap', 'selectedData')])
#def display_click_data(selectedData):
#  return json.dumps(selectedData, indent=2)

name = DAL.get_id_of_things()[0][1].name

data_dict = DAL.get_thing(2)
probe_dict = [1,2,3,4]
app.layout = html.Div([
    html.Div([
        html.H2('Waterbois',
                style={'float': 'left', 'width' : '100%'}),
        html.H3()
    ]),

    html.Div([
#    dcc.Checklist(
#        id='checklist',
#        options=probes,
#    ),

    dcc.Graph(
        id='probeMap',
        figure=fig,
        style={'height': '700px', 'width': '700px'})
    ]),

    html.Div([
            html.Div([
                html.H4(name),
                dcc.Dropdown(id='probe-elements',
                    options=[{'label': s, 'value': s}
                          for s in probe_dict],
                    multi=True
                    )
            ]),

            html.Div([
              html.H4('Specify Interval', style={'textAlign' : 'center', 'horinzontal-align' : 'middle'}),
              html.H6('Start', style={'textAlign': 'center', 'horizontal-align': 'middle', 'width' : '100%'}),
                html.Div(dcc.Input(
                    id="start_date",
                    type="text",
                    placeholder="dd/mm/yyyy"
                ), style={'textAlign': 'center', 'horizontal-align': 'middle'}),
              html.H6('End', style={'textAlign': 'center', 'horizontal-align': 'middle', 'width' : '100%'}),
              html.Div(dcc.Input(
                  id="end_date",
                  type="text",
                  placeholder="dd/mm/yyyy"
                  ), style={'textAlign': 'center', 'horizontal-align': 'middle'}),
              html.Button('Apply', id='date_button',style={'width' : '100%', 'marginTop': 20}),
              html.Div(id='test')
            ]),
        ], style={'width': '15%', 'display': 'inline-block', 'vertical-align': 'top'}),
    html.Div([
        html.Div(id='graphs'),
        html.H4('Select values:'),
        dcc.Dropdown(id='data-elements',
                 options=[{'label': s, 'value': s}
                          for s in data_dict.keys()],
                 multi=True
                 )
    ], style={'display': 'inline-block', 'width':'84%'}),
])


@app.callback(
    Output('test', 'children'),
    [Input('date_button', 'n_clicks'),
     Input('data-elements', 'value')],
    [State('start_date', 'value'),
     State('end_date', 'value')])
def update_time_of_graph(n_clicks, data_names, start_date, end_date):
    return "clicks: {}, start: {}, end: {}, names {}".format(
        n_clicks, start_date, end_date, data_names
    )


def get_updated_values():
    data_dict = DAL.get_thing(id)


'''Dette var vist for at diplaye data for blot én probe'''
'''@app.callback(
    Output('graphs', 'children'),
    [Input('data-elements', 'value')])
def update_graph_data(data_names):
    graphs = []

    data_dict = DAL.get_thing(2)

    if not data_names:

        data = go.Scatter(
            x=list(data_dict["time"]),
            y=list(),
            name='Scatter',
            fill="tozeroy",
            fillcolor="#6897bb",
            mode='lines+markers'
        )
        graphs.append(html.Div(dcc.Graph(

            figure={'data': [data],
                    'layout': go.Layout(xaxis=dict(range=[min(data_dict["time"]), max(data_dict["time"])]),
                                      yaxis=dict(range=[0, 10]),
                                      margin={'l': 50, 'r': 1, 't': 100, 'b': 50},
                                      title='{}'.format('None Selected'))}
        )))
        return graphs

    if 'bat' in data_names:
        P1 = go.Bar(x=[1], y=[1])
        P2 = go.Bar(x=[2], y=[2])
        P3 = go.Bar(x=[3], y=[3])
        P4 = go.Bar(x=[4], y=[4])
        P5 = go.Bar(x=[5], y=[5])

        graphs.append(html.Div(dcc.Graph(
            figure={'data': [P1, P2, P3, P4, P5],
                    'layout': go.Layout(xaxis=dict(range=[0, 10]),
                                        yaxis=dict(range=[0, 10]),
                                        margin={'l': 50, 'r': 1, 't': 40, 'b': 50},
                                        title='{}'.format('Battery Levels'))}
        )))
        return graphs

    for data_name in data_names:

       data = go.Scatter(
            x=list(data_dict["time"]),
            y=list(data_dict[data_name]),
            name='Scatter',
            fill="tozeroy",
            mode="lines+markers",
            fillcolor="#6897bb"
            )
       graphs.append(html.Div(dcc.Graph(
            id=data_name,
            animate=True,
            figure={'data': [data],'layout' : go.Layout(xaxis=dict(range=[min(data_dict["time"]),max(data_dict["time"])]),
                                                        yaxis=dict(range=[min(data_dict[data_name]),max(data_dict[data_name])]),
                                                        margin={'l':50,'r':1,'t':100,'b':50},
                                                        title='{}'.format(data_name))
                                                        }
            )))

    return graphs'''


'''Dette er for flere'''
@app.callback(
    Output('graphs', 'children'),
    [Input('data-elements', 'value'),
     Input('probe-elements', 'value')])
def update_graph_data(data_names, selected_probes):
    graphs = []

    data_dict = DAL.get_thing(2)

    if not data_names:

        data = go.Scatter(
            x=list(data_dict["time"]),
            y=list(),
            name='Scatter',
            fill="tozeroy",
            fillcolor="#6897bb",
            mode='lines+markers'
        )
        graphs.append(html.Div(dcc.Graph(

            figure={'data': [data],
                    'layout': go.Layout(xaxis=dict(range=[min(data_dict["time"]), max(data_dict["time"])]),
                                      yaxis=dict(range=[0, 10]),
                                      margin={'l': 50, 'r': 1, 't': 100, 'b': 50},
                                      title='{}'.format('None Selected'))}
        )))
        return graphs

    data = []
    if 'bat' in data_names:
        for i in range(1, 9):
            data.append(go.Bar(x=[i],
                               y=[data_dict["bat"][i-1]],
                               name="Probe {}".format(i)))

        graphs.append(html.Div(dcc.Graph(
            figure={'data': data,
                    'layout': go.Layout(xaxis=dict(range=[0, 10]),
                                        yaxis=dict(range=[0, 40]),
                                        margin={'l': 50, 'r': 1, 't': 40, 'b': 50},
                                        title='{}'.format('Battery Levels'))}
        )))
        return graphs

    data = []
    names = ""
    min_range = 100000
    max_range = 0
    for data_name in data_names:
        data.append(go.Scatter(
            x=list(data_dict["time"]),
            y=list(data_dict[data_name]),
            name=data_name,
            mode="lines+markers",
            fillcolor="#6897bb"
        ))
        names += data_name + " "
        if min(data_dict[data_name]) < min_range:
            min_range = min(data_dict[data_name])

        if max(data_dict[data_name]) > max_range:
            max_range = max(data_dict[data_name])

    graphs.append(html.Div(dcc.Graph(
        id="data_name",
        animate=True,
        figure={'data': data, 'layout': go.Layout(xaxis=dict(range=[min(data_dict["time"]), max(data_dict["time"])]),
                                                  yaxis=dict(range=[min_range, max_range]),
                                                  margin={'l': 50, 'r': 1, 't': 100, 'b': 50},
                                                  title='Measurements: {}'.format(names))
                }
    )))

    return graphs


if __name__ == '__main__':
    app.run_server(debug=True)
