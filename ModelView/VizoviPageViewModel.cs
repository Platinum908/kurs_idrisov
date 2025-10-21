using kurs_idrisov.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_idrisov.ModelView
{
    internal class VizoviPageViewModel : BaseClass
    {
        private IdentifierContext db = new IdentifierContext();

        private DateTime? startDate;
        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime? endDate;
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private ObservableCollection<DoctorWithDate> filteredDoctors;
        public ObservableCollection<DoctorWithDate> FilteredDoctors
        {
            get => filteredDoctors;
            set
            {
                filteredDoctors = value;
                OnPropertyChanged(nameof(FilteredDoctors));
            }
        }

        private RelayCommand? filterDoctorsCommand;
        public RelayCommand FilterDoctorsCommand
        {
            get
            {
                return filterDoctorsCommand ??
                    (filterDoctorsCommand = new RelayCommand(obj =>
                    {
                        if (StartDate.HasValue && EndDate.HasValue)
                        {
                            var results = db.Priems
                                .Where(p => p.Data.HasValue &&
                                            p.Data.Value >= StartDate.Value &&
                                            p.Data.Value <= EndDate.Value &&
                                            p.Doctor != null)
                                .Select(p => new DoctorWithDate
                                {
                                    Data = p.Data.Value,
                                    DoctorName = p.Doctor.DoctorName
                                })
                                .ToList();

                            FilteredDoctors = new ObservableCollection<DoctorWithDate>(results);
                        }
                        else
                        {
                            FilteredDoctors = new ObservableCollection<DoctorWithDate>();
                        }
                    }));
            }
        }
        public class DoctorWithDate
        {
            public DateTime Data { get; set; }
            public string DoctorName { get; set; }
        }
    }
}
