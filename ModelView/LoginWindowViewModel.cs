using kurs_idrisov.Model;
using kurs_idrisov.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Numerics;

namespace kurs_idrisov.ModelView
{
    class LoginWindowViewModel : BaseClass
    {
        IdentifierContext db = new IdentifierContext();
        private ObservableCollection<Doctor> doctorList;
        public ObservableCollection<Doctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged(nameof(doctorList));
            }
        }

        public LoginWindow window;

        private Doctor? selectDoctor;
        public Doctor? SelectDoctor
        {
            get
            {
                return selectDoctor;
            }
            set
            {
                selectDoctor = value; OnPropertyChanged(nameof(selectDoctor));
            }
        }

        public LoginWindowViewModel(LoginWindow w)
        {
            this.window = w;
            db.Doctors.Load();
            DoctorList = db.Doctors.Local.ToObservableCollection();

            LoginCommand = new RelayCommand(Login);
            CancelCommand = new RelayCommand(Cancel);

        }

        private RelayCommand? addCommands;
        public RelayCommand AddCommands
        {
            get
            {
                return addCommands ??
                    (addCommands = new RelayCommand(obj =>
                    {
                        AddEditDoctor window = new AddEditDoctor(new Doctor());
                        if (window.ShowDialog() == true)
                        {
                            Doctor doctor = window.Doctor;
                            db.Doctors.Add(doctor);
                            db.SaveChanges();
                        }
                    }
                        ));
            }
        }

        private string? doctorLogin;
        public string? DoctorLogin
        {
            get { return doctorLogin; }
            set
            {
                doctorLogin = value; OnPropertyChanged(nameof(DoctorLogin));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }
        public string? qwerty { get; private set; }

        private void Login(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            if (passwordBox == null)
                return;

            string password = passwordBox.Password;
            using (var context = new IdentifierContext())
            {
                var userA = (qwerty == DoctorLogin && qwerty == password);
                if (userA != null)
                {
                    OpenMainWindow();

                    CloseLoginWindow();
                }
                var user = context.Doctors.FirstOrDefault(u => u.DoctorLogin == DoctorLogin && u.DoctorPassword == password);
                if (user != null)
                {

                    OpenMainWindow();

                    CloseLoginWindow();
                }               
            }

        }
        private void OpenMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CloseLoginWindow()
        {
            var loginWindow = Application.Current.Windows.OfType<LoginWindow>().SingleOrDefault();
            if (loginWindow != null)
            {
                loginWindow.Close();
            }
        }

        private void Cancel(object parameter)
        {

            Application.Current.Shutdown();
        }
    }
}
