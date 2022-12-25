﻿using ConvenienceStore.Model;
using ConvenienceStore.Model.Admin;
using ConvenienceStore.ViewModel.Admin.AdminVM;
using ConvenienceStore.Utils.Helpers;
using ConvenienceStore.Views.Admin.SupplierWindow;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConvenienceStore.ViewModel.Admin.Command.SupplierCommand.SupplierCard
{
    public class DeleteSupplierButton : ICommand
    {
        SupplierVM VM;

        public DeleteSupplierButton(SupplierVM VM)
        {
            this.VM = VM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null && (int)parameter - 1 < VM.suppliers.Count)
            {
                return DatabaseHelper.CanDeleteSupplier(VM.suppliers[(int)parameter - 1].Id);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var indexOfSupplier = (int)parameter - 1;

            DatabaseHelper.DeleteSupplier(VM.suppliers[indexOfSupplier].Id);

            VM.ObservableSupplier.RemoveAt(indexOfSupplier);
            VM.suppliers.RemoveAt(indexOfSupplier);

            for (int i = indexOfSupplier; i < VM.suppliers.Count; ++i)
            {
                VM.suppliers[i].Number = i + 1;
            }
        }
    }
}
