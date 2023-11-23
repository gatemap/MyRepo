using System.ComponentModel;
using System.IO;
using System.Windows;

namespace WpfStudy04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string filePath = "C:\\Users\\space\\Desktop\\MyRepo\\WPF\\WpfStudy04\\WpfStudy04\\urlText.fvr";
        int backCount = 0;
        FileInfo fi;

        public MainWindow()
        {
            InitializeComponent();

            /*
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("하마", 10));
            animals.Add(new Animal("타조", 90));
            animals.Add(new Animal("토끼", 50));

            listBox.ItemsSource = animals;
            */

            forwardButton.IsEnabled = backCount > 0 ? true : false;
            fi = new FileInfo(filePath);

            if(fi.Exists)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(filePath);
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = streamReader.ReadLine();
                        listBox.Items.Add(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (listBox.Items.Count < 1)
                return;

            try
            {
                StreamWriter writer = new StreamWriter(filePath);

                foreach (var item in listBox.Items)
                    writer.WriteLine(item.ToString());

                writer.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            backCount++;
            webBrowser.GoBack();
            forwardButton.IsEnabled = true;
        }

        private void Button_Click_Forward(object sender, RoutedEventArgs e)
        {
            backCount--;
            webBrowser.GoForward();

            if (backCount < 1)
                forwardButton.IsEnabled = false;
        }

        private void Button_Click_Favorite(object sender, RoutedEventArgs e)
        {
            // 추가에 체크 되어있는 경우
            if(addRadioButton.IsChecked == true)
            {
                listBox.Items.Add(urlTextBox.Text);

                if (listBox.Items.Count < 1)
                    return;

                fi = new FileInfo(filePath);
                StreamWriter writer;

                if (fi.Exists)
                {
                    try
                    {
                        writer = new StreamWriter(filePath, true);
                        writer.WriteLine(urlTextBox.Text);
                        writer.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        writer = new StreamWriter(filePath);
                        writer.WriteLine(urlTextBox.Text);
                        writer.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
            }
            else if(loadRadioButton.IsChecked == true)
            {
                urlTextBox.Text = listBox.SelectedItem.ToString();
                webBrowser.Navigate(urlTextBox.Text);
            }
        }

        private void Button_Click_Move_Url(object sender, RoutedEventArgs e)
        {
            webBrowser.Navigate(urlTextBox.Text);
        }
    }
}