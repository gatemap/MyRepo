using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudy01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            ImageSource currentImage = testImage.Source;

            Uri source = new Uri(@"/WpfStudy01;component/Resources/감사콩.jpg", UriKind.Relative);
            ImageSource nextImage = new BitmapImage(source);

            if(!currentImage.Equals(nextImage))
            {
                testImage.Source = nextImage;
                nextImage = currentImage;
                currentImage = testImage.Source;
            }

            // testImage.Source = new BitmapImage(source);
        }
    }
}
