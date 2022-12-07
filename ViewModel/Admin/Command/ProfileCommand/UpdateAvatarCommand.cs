﻿using ConvenienceStore.Model;
using ConvenienceStore.Utils.Helpers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConvenienceStore.ViewModel.Admin.Command.ProfileCommand
{
    public class UpdateAvatarCommand : ICommand
    {
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
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.jpeg;*.jpg;*.png";
            openDialog.FilterIndex = -1;

            BitmapImage bi = new BitmapImage();
            byte[] bytes = null;

            if (openDialog.ShowDialog() == true)
            {
                bytes = System.IO.File.ReadAllBytes(openDialog.FileName);
                string s = Convert.ToBase64String(bytes);

                bi.BeginInit();
                bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(s));
                bi.EndInit();
            }
            var imageBrush = (ImageBrush)parameter;

            try
            {
                imageBrush.ImageSource = bi;
            }
            catch
            {
                /* Chỗ này phải xài try catch để bắt lỗi
                 * Người dùng mở File Exploer nhưng không chọn ảnh mà nhấn nút "Cancle" */
            }

            if (bytes != null)
                DatabaseHelper.UpdateProfileAvatar(bytes);

        }
    }
}
