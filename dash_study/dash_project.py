from dash import Dash, html, dcc, callback, Output, Input, dash_table
import plotly.express as px
import pandas as pd

def main() :
    
    dt = pd.read_csv('C:/Users/space/Desktop/MyRepo/dash_study/서울시 코로나19 확진자 발생동향 (2023.05.31.이전).csv', encoding='EUC-KR')
    dt['서울시 기준일'].sort_values()
    
    app = Dash(__name__)
    
    app.layout = html.Div([
    html.H1(children='서울시 코로나19 확진자 발생동향', style={'textAlign' : 'center'}),
    #dcc.Dropdown(df.country.unique(), 'Canada', id='dropdown-selection'),
    #dcc.Graph(id='graph-content')
    #dash_table.DataTable(dt.to_dict('records'))
    dash_table.DataTable(dt.to_dict('records'),[{"name": i, "id": i} for i in dt.columns], id='tbl')
])
    
    
    app.run(debug=True)
    
if __name__ == '__main__' :
    main()