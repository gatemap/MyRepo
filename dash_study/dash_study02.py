import datetime

import dash
from dash import Dash, dcc, html, Input, Output, callback
import plotly

# pip install pyorbital
from pyorbital.orbital import Orbital

satellite = Orbital('TERRA')

# dash에서 제공하는 bootstrap
external_stylesheets = ['https://codepen.io/chriddyp/pen/bWLwgP.css']

# dash 초기화 해주면서 스타일 시트 적용
app = Dash(__name__, external_stylesheets=external_stylesheets)

# 화면 구성
app.layout = html.Div(
    html.Div([
        # 제목
        html.H4('TERRA Satellite Live Feed'),
        # 그래프가 담길 공간
        html.Div(id='live-update-text'),
        # 그래프 그리기
        dcc.Graph(id='live-update-graph'),
        # 1초마다 업데이트, callback함수에 묶여서 사용될 예정
        dcc.Interval(
            id='interval-component',
            interval=1*1000, # in milliseconds
            n_intervals=0
        )
    ])
)

# 콜백 함수. interval값이 in으로 들어가면 text업데이트를 output으로 내뱉고
@callback(Output('live-update-text', 'children'),
              Input('interval-component', 'n_intervals'))
def update_metrics(n):
    # Calculate sublon, sublat and altitude of satellite.
    # 위성의 sublon, sublat, altitude 라는걸 계산한걸 받아옴
    lon, lat, alt = satellite.get_lonlatalt(datetime.datetime.now())
    # 스타일 지정(css)
    style = {'padding': '5px', 'fontSize': '16px'}
    return [
        html.Span('Longitude: {0:.2f}'.format(lon), style=style),
        html.Span('Latitude: {0:.2f}'.format(lat), style=style),
        html.Span('Altitude: {0:0.2f}'.format(alt), style=style)
    ]


# Multiple components can update everytime interval gets fired.
@callback(Output('live-update-graph', 'figure'),
              Input('interval-component', 'n_intervals'))
def update_graph_live(n):
    satellite = Orbital('TERRA')
    data = {
        'time': [],
        'Latitude': [],
        'Longitude': [],
        'Altitude': []
    }

    # Collect some data
    for i in range(180):
        time = datetime.datetime.now() - datetime.timedelta(seconds=i*20)
        lon, lat, alt = satellite.get_lonlatalt(
            time
        )
        # 받아온 데이터들을 위에서 만든 data에 넣는다(추가)
        data['Longitude'].append(lon)
        data['Latitude'].append(lat)
        data['Altitude'].append(alt)
        data['time'].append(time)

    # Create the graph with subplots
    # 그래프 css적인 설정
    fig = plotly.tools.make_subplots(rows=2, cols=1, vertical_spacing=0.2)
    fig['layout']['margin'] = {
        'l': 30, 'r': 10, 'b': 30, 't': 10
    }
    fig['layout']['legend'] = {'x': 0, 'y': 1, 'xanchor': 'left'}

    # append_trace는 plotly에서 사용되는 라이브러리의 메소드이다.
    # 다중 그래프를 하나의 그래프에 추가하거나 결합할 때 사용함
    # 즉, 그래프 2개를 그리기 위해 값들을 설정하는 것
    fig.append_trace({
        'x': data['time'],
        'y': data['Altitude'],
        'name': 'Altitude',
        # 선과 점을 함께 그린다는 뜻
        'mode': 'lines+markers',
        # 산점도 그래프
        'type': 'scatter'
    }, 1, 1)
    fig.append_trace({
        'x': data['Longitude'],
        'y': data['Latitude'],
        'text': data['time'],
        'name': 'Longitude vs Latitude',
        'mode': 'lines+markers',
        'type': 'scatter'
    }, 2, 1)

    return fig


if __name__ == '__main__':
    app.run(debug=True)