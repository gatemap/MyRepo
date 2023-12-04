using ScottPlot;
using ScottPlot.Plottable;
using ScottPlot.Renderable;
using System.Drawing;
using System.Windows;

namespace WpfStudy05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Crosshair crosshair;
        Tooltip tooltip;

        public MainWindow()
        {
            InitializeComponent();

            //ScatterPlotExample();
            //SignalPlotExample();
            //LegendExample();
            PrimaryAxesExample();
            //AdditionalYAxesExample();

            // x,y 좌표 표시
            crosshair = WpfPlot1.Plot.AddCrosshair(0, 0);

            tooltip = new Tooltip();

            // 배경 투명화
            WpfPlot1.Plot.Style(figureBackground: Color.Transparent);
            WpfPlot1.Plot.Style(dataBackground: Color.Transparent);
            WpfPlot1.Refresh();
        }

        void ScatterPlotExample()
        {
            // sample data
            double[] xs = DataGen.Consecutive(51);
            double[] sin = DataGen.Sin(51);
            double[] cos = DataGen.Cos(51);

            // plot the data
            // 플롯에 데이터 추가하는 법(x값, y값)
            WpfPlot1.Plot.AddScatter(xs, sin);
            WpfPlot1.Plot.AddScatter(xs, cos);

            // customize the axis labels
            // 그래프 타이틀, x축 명명, y축 명명 설정
            WpfPlot1.Plot.Title("ScottPlot Quickstart");
            WpfPlot1.Plot.XLabel("Horizontal Axis");
            WpfPlot1.Plot.YLabel("Vertical Axis");

            //WpfPlot1.Plot.SaveFig("quickstart_scatter.png");
        }

        void SignalPlotExample()
        {
            double[] values = DataGen.RandomWalk(1_000_000);
            // sampleRate는 신호 데이터의 샘플링 속도를 나타낸다고 함
            // 데이터 48000개씩 선형보간한다고 볼 수 있음
            WpfPlot1.Plot.AddSignal(values, sampleRate: 48_000);
            WpfPlot1.Plot.Title("One Million Points");

            //WpfPlot1.Plot.SaveFig("quickstart_signal.png");
        }

        void LegendExample()
        {
            double[] xs = DataGen.Consecutive(51);
            double[] sin = DataGen.Sin(51);
            double[] cos = DataGen.Cos(51);

            // x, y, 이 그래프가 그리는 의미?
            WpfPlot1.Plot.AddScatter(xs, sin, label: "sin");
            WpfPlot1.Plot.AddScatter(xs, cos, label: "cos");
            // 범례를 띄워라
            WpfPlot1.Plot.Legend();
        }

        void PrimaryAxesExample()
        {
            var sigSmall = WpfPlot1.Plot.AddSignal(DataGen.Sin(51, mult: 1), sampleRate: 1);
            sigSmall.YAxisIndex = WpfPlot1.Plot.LeftAxis.AxisIndex;
            sigSmall.XAxisIndex = WpfPlot1.Plot.BottomAxis.AxisIndex;
            WpfPlot1.Plot.BottomAxis.Label("Primary X Axis");
            WpfPlot1.Plot.YAxis.Label("Primary Y Axis");
            WpfPlot1.Plot.BottomAxis.Color(sigSmall.Color);
            WpfPlot1.Plot.YAxis.Color(sigSmall.Color);

            // plot another set of data using the secondary axes
            var sigBig = WpfPlot1.Plot.AddSignal(DataGen.Cos(51, mult: 100), sampleRate: 100);
            sigBig.YAxisIndex = WpfPlot1.Plot.RightAxis.AxisIndex;
            sigBig.XAxisIndex = WpfPlot1.Plot.TopAxis.AxisIndex;

            // show ticks and labels for axes where they are hidden by default
            WpfPlot1.Plot.RightAxis.Ticks(true);
            WpfPlot1.Plot.RightAxis.Color(sigBig.Color);
            WpfPlot1.Plot.RightAxis.Label("Secondary Y Axis");
            WpfPlot1.Plot.TopAxis.Ticks(true);
            WpfPlot1.Plot.TopAxis.Color(sigBig.Color);
            WpfPlot1.Plot.TopAxis.Label("Secondary X Axis");

            (double coordinateX, double coordinateY) = WpfPlot1.GetMouseCoordinates();
        }

        void AdditionalYAxesExample()
        {
            // plot one set of data using the primary Y axis
            var sigSmall = WpfPlot1.Plot.AddSignal(DataGen.Sin(51, mult: 1));
            sigSmall.YAxisIndex = WpfPlot1.Plot.LeftAxis.AxisIndex;
            WpfPlot1.Plot.YAxis.Label("Primary Axis");
            WpfPlot1.Plot.YAxis.Color(sigSmall.Color);

            // plot another set of data using an additional axis
            var sigBig = WpfPlot1.Plot.AddSignal(DataGen.Cos(51, mult: 100));
            var yAxis3 = WpfPlot1.Plot.AddAxis(Edge.Left);
            sigBig.YAxisIndex = yAxis3.AxisIndex;
            yAxis3.Label("Additional Axis");
            yAxis3.Color(sigBig.Color);
        }

        private void OnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            int pixelX = (int)e.MouseDevice.GetPosition(WpfPlot1).X;
            int pixelY = (int)e.MouseDevice.GetPosition(WpfPlot1).Y;

            (double coordinateX, double coordinateY) = WpfPlot1.GetMouseCoordinates();

            crosshair.X = coordinateX; crosshair.Y = coordinateY;
            WpfPlot1.Refresh();
        }

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            crosshair.IsVisible = true;
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            crosshair.IsVisible = false;
            WpfPlot1.Refresh();
        }

        private void OnMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int pixelX = (int)e.MouseDevice.GetPosition(WpfPlot1).X;
            int pixelY = (int)e.MouseDevice.GetPosition(WpfPlot1).Y;

            (double coordinateX, double coordinateY) = WpfPlot1.GetMouseCoordinates();

            WpfPlot1.Plot.Remove(tooltip);
            tooltip = WpfPlot1.Plot.AddTooltip(label: $"{coordinateX.ToString("F5")}, {coordinateY.ToString("F5")}", coordinateX, coordinateY);
            //WpfPlot1.Plot.AddTooltip(label: $"{coordinateX.ToString("F5")}, {coordinateY.ToString("F5")}", coordinateX, coordinateY);
                
            //WpfPlot1.Refresh();
        }
    }   
}