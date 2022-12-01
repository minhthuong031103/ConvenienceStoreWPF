﻿using ConvenienceStore.Model.Lam;
using ConvenienceStore.ViewModel.Lam.Command.SupplierCommand.AddNewSupplierCommand;
using ConvenienceStore.ViewModel.Lam.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenienceStore.ViewModel.Lam
{
    public class SupplierVM : INotifyPropertyChanged
    {
        public ObservableCollection<Supplier> suppliers { get; set; }

        private Supplier selectedSupplier;

        public Supplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                selectedSupplier = value;
                OnPropertyChanged("SelectedSupplier");
            }
        }

        private string searchContent;

        public string SearchContent
        {
            get { return searchContent; }
            set
            {
                searchContent = value;
                OnPropertyChanged("SearchContent");

            }
        }

        public AddSupplierButtonCommand AddSupplierButtonCommand { get; set; }

        public SupplierVM()
        {
            suppliers = DatabaseHelper.FetchingSupplier();

            AddSupplierButtonCommand = new AddSupplierButtonCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}