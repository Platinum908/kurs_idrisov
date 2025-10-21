using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kurs_idrisov.Model;
using kurs_idrisov.View;
using Microsoft.EntityFrameworkCore;

namespace kurs_idrisov.ModelView
{
    internal class DoctorPageViewModel : BaseClass
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
                OnPropertyChanged(nameof(DoctorList));
            }
        }

        private Doctor? selectDoctor;
        public Doctor? SelectDoctor
        {
            get
            {
                return selectDoctor;
            }
            set
            {
                selectDoctor = value; OnPropertyChanged(nameof(SelectDoctor));
            }
        }

        public DoctorPage window;

        public DoctorPageViewModel(DoctorPage w)
        {
            this.window = w;
            db.Doctors.Load();
            DoctorList = db.Doctors.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditDoctor window = new AddEditDoctor(new Doctor());
                        if (window.ShowDialog() == true)
                        {
                            Doctor doctor = window.Doctor;
                            db.Doctors.Local.Add(doctor);
                            db.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(obj =>
                    {
                        Doctor? doctor = obj as Doctor;
                        if (doctor == null) return;
                        AddEditDoctor window = new AddEditDoctor(doctor!);
                        if (window.ShowDialog() == true)
                        {
                            doctor.DoctorName = window.Doctor.DoctorName;
                            doctor.DoctorLogin = window.Doctor.DoctorLogin;
                            doctor.DoctorPassword = window.Doctor.DoctorPassword;
                            db.SaveChanges();
                        }
                    }));
            }
        }

        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        Doctor? doctor = selectDoctor as Doctor;
                        if (doctor == null) return;
                        db.Doctors.Remove(doctor);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
