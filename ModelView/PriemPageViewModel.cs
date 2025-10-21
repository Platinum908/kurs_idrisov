using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using kurs_idrisov.Model;
using kurs_idrisov.View;
using Microsoft.EntityFrameworkCore;

namespace kurs_idrisov.ModelView
{
    internal class PriemPageViewModel : BaseClass
    {
        IdentifierContext db = new IdentifierContext();
        private ObservableCollection<Priem> priemList;
        public ObservableCollection<Priem> PriemList
        {
            get { return priemList; }
            set
            {
                priemList = value;
                OnPropertyChanged(nameof(PriemList));
            }
        }

        public PriemPage window;

        private Priem? selectPriem;
        public Priem? SelectPriem
        {
            get { return selectPriem; }
            set
            {
                selectPriem = value; OnPropertyChanged(nameof(SelectPriem));
            }
        }

        public PriemPageViewModel(PriemPage w)
        {
            this.window = w;
            var priems = db.Priems
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .Include(p => p.Drug)
                .ToList();

            PriemList = new ObservableCollection<Priem>(priems);
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditPriem window = new AddEditPriem(new Priem());
                        if (window.ShowDialog() == true)
                        {
                            Priem priem = window.Priem;
                            db.Priems.Local.Add(priem);
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
                        Priem? priem = obj as Priem;
                        if (priem == null) return;
                        AddEditPriem window = new AddEditPriem(priem!);
                        if (window.ShowDialog() == true)
                        {
                            priem.PriemId = window.Priem.PriemId;
                            priem.Data = window.Priem.Data;
                            priem.Mesto = window.Priem.Mesto;
                            priem.Simptomi = window.Priem.Simptomi;
                            priem.Diagnoz = window.Priem.Diagnoz;
                            priem.Naznachenie = window.Priem.Naznachenie;
                            priem.PatientId = window.Priem.PatientId;
                            priem.DrugId = window.Priem.DrugId;
                            priem.DoctorId = window.Priem.DoctorId;
                            db.Entry(priem).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        Priem? priem = selectPriem as Priem;
                        if (priem == null) return;
                        db.Priems.Remove(priem);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
