using System;
using System.IO;
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
using Microsoft.Win32;

namespace WpfStudy02
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

        private void Button_Click_OpenCsvFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";

            // 창이 열리고
            if(openFileDialog.ShowDialog() == true)
            {
                string fileContent = File.ReadAllText(openFileDialog.FileName);
                filePathLabel.Content = openFileDialog.FileName;
                string[] splitContent = fileContent.Split('\n');
                
                List<Person> listPerson = new List<Person>();

                for(int i = 0; i < splitContent.Length; i++)
                {
                    string[] parts = splitContent[i].Split(',');

                    // 이름 끝에 '세' 붙어 있는거 지워주기
                    parts[1] = parts[1].Remove(parts[1].IndexOf('세'));

                    // 나이변환 체크
                    if (int.TryParse(parts[1], out int age))
                        listPerson.Add(new Person(parts[0], age, parts[2]));
                    else
                        listPerson.Add(new Person(parts[0], 0, parts[2]));
                }

                personDataList.ItemsSource = listPerson;
            }
        }

        private void Button_Click_GetData(object sender, RoutedEventArgs e)
        {
            string dataContent = "선택된 데이터 : ";

            if (personDataList.SelectedItems.Count == 1)
            {
                Person person = (Person)personDataList.SelectedItem;
                dataContent += $"{person.name}, {person.age}, {person.note}";
            }
            else if(personDataList.SelectedItems.Count > 1)
            {
                dataContent += "\r\n";

                foreach(Person person in personDataList.SelectedItems)
                    dataContent += $"{person.name}, {person.age}, {person.note}";
            }

            MessageBox.Show(dataContent);
        }
    }
}