﻿using ConvenienceStore.ViewModel.Admin.AdminVM;
using ConvenienceStore.Views.Admin.InputInfoWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConvenienceStore.ViewModel.Admin.Command.InputInfoCommand.DeleteInputInfoCommand
{
    public class OpenAlertDialog : ICommand
    {
        InputInfoVM VM;
        public OpenAlertDialog(InputInfoVM VM)
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
            return true;
        }

        public void Execute(object parameter)
        {
            var alertDialog = new AlertDialogDeleteInputInfo()
            {
                DataContext = VM,
            };
            alertDialog.ShowDialog();
        }
    }
}