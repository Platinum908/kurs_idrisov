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
    internal class DrugPageViewModel : BaseClass
    {
        IdentifierContext db = new IdentifierContext();
        private ObservableCollection<Drug> drugList;
        public ObservableCollection<Drug> DrugList
        {
            get
            {
                return drugList;
            }
            set
            {
                drugList = value;
                OnPropertyChanged(nameof(DrugList));
            }
        }
        public DrugPage window;

        private Drug? selectDrug;
        public Drug? SelectDrug
        {
            get
            {
                return selectDrug;
            }
            set
            {
                selectDrug = value; OnPropertyChanged(nameof(SelectDrug));
            }
        }

        public DrugPageViewModel(DrugPage w)
        {
            this.window = w;
            db.Drugs.Load();
            DrugList = db.Drugs.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditDrug window = new AddEditDrug(new Drug());
                        if (window.ShowDialog() == true)
                        {
                            Drug drug = window.Drug;
                            db.Drugs.Local.Add(drug);
                            db.SaveChanges();
                        }
                    }
                    ));
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
                        Drug? drug = obj as Drug;
                        if (drug == null) return;
                        AddEditDrug window = new AddEditDrug(drug!);
                        if (window.ShowDialog() == true)
                        {
                            drug.DrugId = window.Drug.DrugId;
                            drug.DrugName = window.Drug.DrugName;
                            drug.SposobPriema = window.Drug.SposobPriema;
                            drug.Deistvie = window.Drug.Deistvie;
                            drug.PobochnieEffects = window.Drug.PobochnieEffects;
                            db.Entry(drug).State = EntityState.Modified;
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
                    (deleteCommand = new RelayCommand(selectDoctor =>
                    {
                        Drug? drug = selectDrug as Drug;
                        if (drug == null) return;
                        db.Drugs.Remove(drug);
                        db.SaveChanges();
                    }
                    ));
            }
        }
    }
}
