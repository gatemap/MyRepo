using System.Windows;
using OpenCvSharp;

namespace OpenCVStudy01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            versionTextBox.Text = Cv2.GetVersionString();

            // exe 파일 있는 위치에 이미지 파일을 두면 됨
            Mat img = Cv2.ImRead("방긋로아콘.jpg");

            // 새창 생성
            Cv2.ImShow("Image Test", img);

            imageBox.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(img);
        }
    }
}