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
    /// Логика взаимодействия для AddEditDoctor.xaml
    /// </summary>
    public partial class AddEditDoctor : Window
    {
        public Doctor Doctor { get; private set; }
        public AddEditDoctor(Doctor doctor)
        {
            InitializeComponent();
            Doctor = doctor;
            DataContext = Doctor;
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
