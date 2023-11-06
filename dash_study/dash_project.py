import dash
from dash import Dash, html, dcc, callback, Output, Input, dash_table
import plotly.express as px
import pandas as pd

def main() :
    
    df = pd.read_csv('C:/Users/space/Desktop/MyRepo/dash_study/서울시 코로나19 확진자 발생동향 (2023.05.31.이전).csv', encoding='EUC-KR')
    
    # 역순으로 만들기
    df = df[::-1]
    
    app = Dash(__name__)
    
    app.layout = html.Div([
    html.H1(children='서울시 코로나19 확진자 발생동향', style={'textAlign' : 'center'}),
    dcc.Graph(id='graph-content'),
    dcc.Interval(
        id='interval-component',
        interval=1000,
        n_intervals=0
    )
])
   
    @callback(
        Output('graph-content', 'figure'),
        Input('interval-component', 'n_intervals')
    )
    def update_graph(s) : 
        
        #start_idx = s * 20
        end_idx = (s + 1) * 20
        data_plot = df[:end_idx]
        
        figure = {
            'data' : [
                {'x' : data_plot['서울시 기준일'], 'y' : data_plot['서울시 사망'] / data_plot['서울시 확진자'] * 100, 'type' : 'line'}],
            'layout' : {
                'xaxis' : {'title' : '서울시 기준일'},
                'yaxis' : {'title' : '서울시 사망률(%)'}
            }
        }
        
        # 마지막에 도달하면 더이상 update하지 않음
        if data_plot.index[-1] == df.index[-1] :
            raise dash.exceptions.PreventUpdate
        
        return figure
    
    app.run(debug=True)
    
    
    
def drawPerDeathGraph(df, fig, s) :
    # 역순으로 만들기
    df = df[::-1]
    
    end_idx = (s + 1) * 20
    data_plot = df[:end_idx]
    
    fig.append_trace({
        'x':data_plot['서울시 기준일'],
        'y':data_plot['서울시 사망'] / data_plot['서울시 확진자'] * 100,
        'name' : '서울시 확진 대비 사망률',
        'mode' : 'line'
    }, 1, 1)
    
    
if __name__ == '__main__' :
    main()