using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfStudy01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageSource currentImage;
        ImageSource nextImage;

        Uri source;
        Uri buttonSource;


        public MainWindow()
        {
            InitializeComponent();

            currentImage = testImage.Source;

            source = new Uri(@"/WpfStudy01;component/Resources/감사콩.jpg", UriKind.Relative);
            nextImage = new BitmapImage(source);

            buttonSource = new Uri(@"pack://application:,,,/Resources/love.png", UriKind.Absolute);
            BitmapImage image = new BitmapImage(buttonSource);
            changeButton.Background = new ImageBrush(new BitmapImage(buttonSource));
            changeButton.Width = image.PixelWidth;
            changeButton.Height = image.PixelHeight;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HelloButton.IsChecked == true)
                MessageBox.Show("Hello.");
            else if (GoodbyeButton.IsChecked == true)
                MessageBox.Show("Goodbye.");
        }

        private void Button_Click_ResourceLoad(object sender, RoutedEventArgs e)
        {
            if(!currentImage.Equals(nextImage))
            {
                testImage.Source = nextImage;
                nextImage = currentImage;
                currentImage = testImage.Source;
            }
        }

        private void Button_Click_ImageChange(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            // 이미지만 받아오도록 이미지 확장자 필터
            fileDialog.Filter = "Image files (*.png 혹은 *.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (fileDialog.ShowDialog().Equals(true))
            {
                buttonSource = new Uri(fileDialog.FileName, UriKind.Absolute);
                BitmapImage image = new BitmapImage(buttonSource);
                changeButton.Background = new ImageBrush(new BitmapImage(buttonSource));
                changeButton.Width = image.PixelWidth; changeButton.Height = image.PixelHeight;
            }
        }
    }
}
