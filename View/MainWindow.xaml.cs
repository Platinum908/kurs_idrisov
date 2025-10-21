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
using kurs_idrisov.Model;
using kurs_idrisov.View;

namespace kurs_idrisov
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
            FrameContainer.Navigate(new PatientPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new DoctorPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new PriemPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new DrugPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new VizoviPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new BolezniPage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new EffectsPage());
        }
    }
}