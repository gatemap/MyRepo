using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudy03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 초기화
            origin.IsChecked = true;
            grey.IsChecked = false;
            invert.IsChecked = false;

            redSlider.Value = 255;
            greenSlider.Value = 255;
            blueSlider.Value = 255;

            CheckColorType();
        }

        /// <summary>
        /// 실제 화면 색상을 바꿔주는 함수
        /// </summary>
        /// <param name="r">rgb의 r값</param>
        /// <param name="g">rgb의 g값</param>
        /// <param name="b">rgb의 b값</param>
        void ChangeMainGridColor(byte r, byte g, byte b)
        {
            mainGrid.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        /// <summary>
        /// radio버튼이 어디에 체크되어있는지 확인해서 함수를 호출한다
        /// </summary>
        void CheckColorType()
        {
            // 기본 체크
            if (origin.IsChecked == true)
                ChangeMainGridColor((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value);
            // 흑백 체크
            else if (grey.IsChecked == true)
            {
                int avg = (int)(redSlider.Value + greenSlider.Value + blueSlider.Value) / 3;
                ChangeMainGridColor((byte)avg, (byte)avg, (byte)avg);
            }
            // 반전 체크
            else if (invert.IsChecked == true)
            {
                byte r = (byte)(255 - redSlider.Value);
                byte g = (byte)(255 - greenSlider.Value);
                byte b = (byte)(255 - blueSlider.Value);

                ChangeMainGridColor(r, g, b);
            }
        }

        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CheckColorType();
            redValue.Content = (int)redSlider.Value;
        }

        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CheckColorType();
            greenValue.Content = (int)greenSlider.Value;
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CheckColorType();
            blueValue.Content = (int)blueSlider.Value;
        }

        private void Origin_Checked(object sender, RoutedEventArgs e)
        {
            CheckColorType();
        }

        private void Grey_Checked(object sender, RoutedEventArgs e)
        {
            CheckColorType();
        }

        private void Invert_Checked(object sender, RoutedEventArgs e)
        {
            CheckColorType();
        }
    }
}