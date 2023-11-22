using System.Text;
using System.Windows;

namespace WpfStudy04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("하마", 10));
            animals.Add(new Animal("타조", 90));
            animals.Add(new Animal("토끼", 50));

            listBox.ItemsSource = animals;
        }
    }
}