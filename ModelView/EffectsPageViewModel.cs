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
    internal class EffectsPageViewModel : BaseClass
    {
        private IdentifierContext db = new IdentifierContext();

        private ObservableCollection<Drug> drugList;
        public ObservableCollection<Drug> DrugList
        {
            get { return drugList; }
            set
            {
                drugList = value;
                OnPropertyChanged(nameof(DrugList));
            }
        }
        public EffectsPageViewModel()
        {
            db.Drugs.Load();
            DrugList = db.Drugs.Local.ToObservableCollection();

        }
        private string selectedDrug;
        public string SelectedDrug
        {
            get { return selectedDrug; }
            set
            {
                selectedDrug = value;
                OnPropertyChanged(nameof(SelectedDrug));
            }
        }

        private RelayCommand? filterByDrugCommand;
        public RelayCommand FilterByDrugCommand
        {
            get
            {
                return filterByDrugCommand ??
                    (filterByDrugCommand = new RelayCommand(obj =>
                    {
                        if (!string.IsNullOrEmpty(SelectedDrug))
                        {
                            var filteredDrugs = db.Drugs
                                .Where(a => a.DrugName == SelectedDrug)
                                .ToList();
                            DrugList = new ObservableCollection<Drug>(filteredDrugs);
                        }
                        else
                        {
                            db.Drugs.Load();
                            DrugList = db.Drugs.Local.ToObservableCollection();
                        }
                    }));
            }
        }
    }
}
