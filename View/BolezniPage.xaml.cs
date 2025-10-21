using kurs_idrisov.Model;
using kurs_idrisov.ModelView;
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
    /// Логика взаимодействия для BolezniPage.xaml
    /// </summary>
    public partial class BolezniPage : Page
    {
        public BolezniPage()
        {
            InitializeComponent();
            DataContext = new BolezniPageViewModel();
        }
    }
}
