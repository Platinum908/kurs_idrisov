using kurs_idrisov.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace kurs_idrisov.ModelView
{
    internal class BolezniPageViewModel : BaseClass
    {
        private IdentifierContext db = new IdentifierContext();

        private ObservableCollection<PriemWithPatient> priemList;
        public ObservableCollection<PriemWithPatient> PriemList
        {
            get => priemList;
            set
            {
                priemList = value;
                OnPropertyChanged(nameof(PriemList));
            }
        }

        public BolezniPageViewModel()
        {
            var all = db.Priems
                .Select(p => new PriemWithPatient
                {
                    Diagnoz = p.Diagnoz,
                    PatientName = p.Patient.PatientName
                })
                .ToList();

            PriemList = new ObservableCollection<PriemWithPatient>(all);
        }

        private string selectedDiagnoz;
        public string SelectedDiagnoz
        {
            get => selectedDiagnoz;
            set
            {
                selectedDiagnoz = value;
                OnPropertyChanged(nameof(SelectedDiagnoz));
            }
        }

        private RelayCommand? filterByDiagnozCommand;
        public RelayCommand FilterByDiagnozCommand
        {
            get
            {
                return filterByDiagnozCommand ??
                    (filterByDiagnozCommand = new RelayCommand(obj =>
                    {
                        if (!string.IsNullOrEmpty(SelectedDiagnoz))
                        {
                            var filtered = db.Priems
                                .Where(p => p.Diagnoz == SelectedDiagnoz)
                                .Select(p => new PriemWithPatient
                                {
                                    Diagnoz = p.Diagnoz,
                                    PatientName = p.Patient.PatientName
                                })
                                .ToList();

                            PriemList = new ObservableCollection<PriemWithPatient>(filtered);
                        }
                        else
                        {
                            var all = db.Priems
                                .Select(p => new PriemWithPatient
                                {
                                    Diagnoz = p.Diagnoz,
                                    PatientName = p.Patient.PatientName
                                })
                                .ToList();

                            PriemList = new ObservableCollection<PriemWithPatient>(all);
                        }
                    }));
            }
        }

        public class PriemWithPatient
        {
            public string? Diagnoz { get; set; }
            public string? PatientName { get; set; }
        }
    }
}
