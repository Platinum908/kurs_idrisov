using kurs_idrisov.Model;
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

namespace kurs_idrisov.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditPatient.xaml
    /// </summary>
    public partial class AddEditPatient : Window
    {
        public Patient Patient { get; private set; }
        public AddEditPatient(Patient patient)
        {
            InitializeComponent();
            Patient = patient;
            DataContext = Patient;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
