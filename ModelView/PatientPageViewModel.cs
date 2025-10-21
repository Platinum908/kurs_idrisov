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
    internal class PatientPageViewModel : BaseClass
    {
        IdentifierContext db = new IdentifierContext();
        private ObservableCollection<Patient> patientList;
        public ObservableCollection<Patient> PatientList
        {
            get { return patientList; }
            set
            {
                patientList = value;
                OnPropertyChanged(nameof(PatientList));
            }
        }

        public PatientPage window;

        private Patient? selectPatient;
        public Patient? SelectPatient
        {
            get { return selectPatient; }
            set
            {
                selectPatient = value; OnPropertyChanged(nameof(SelectPatient));

            }
        }

        public PatientPageViewModel(PatientPage w)
        {
            this.window = w;
            db.Patients.Load();
            PatientList = db.Patients.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditPatient window = new AddEditPatient(new Patient());
                        if (window.ShowDialog() == true)
                        {
                            Patient patient = window.Patient;
                            db.Patients.Local.Add(patient);
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
                        Patient? patient = obj as Patient;
                        if (patient == null) return;
                        AddEditPatient window = new AddEditPatient(patient!);
                        if (window.ShowDialog() == true)
                        {
                            patient.PatientId = window.Patient.PatientId;
                            patient.PatientName = window.Patient.PatientName;
                            patient.Pol = window.Patient.Pol;
                            patient.DataRosdeniya = window.Patient.DataRosdeniya;
                            patient.Adres = window.Patient.Adres;
                            db.Entry(patient).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    ));
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
                        Patient? patient = selectPatient as Patient;
                        if (patient == null) return;
                        db.Patients.Remove(patient);
                        db.SaveChanges();
                    }
                    ));
            }
        }
    }
}
