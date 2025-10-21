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
    /// Логика взаимодействия для AddEditPriem.xaml
    /// </summary>
    public partial class AddEditPriem : Window
    {
        private IdentifierContext IdentifierContext = new IdentifierContext();
        public Priem Priem { get; private set; }
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Drug> Drugs { get; set; }
        public AddEditPriem(Priem priem)
        {
            InitializeComponent();
            Priem = priem;           
            DataContext =Priem;

            ComboBoxPatientId.ItemsSource = IdentifierContext.Patients.ToList();
            ComboBoxDoctorId.ItemsSource = IdentifierContext.Doctors.ToList();
            ComboBoxDrugId.ItemsSource = IdentifierContext.Drugs.ToList();
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
