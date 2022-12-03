﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using ConvenienceStore.Views;
using ConvenienceStore.DataLayerAccess;
using ConvenienceStore.Model;
using ConvenienceStore.Views.Staff;

namespace ConvenienceStore.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {

        public ICommand PasswordChangedCommand { get; set; }
        public ICommand OpenSignUpWindowCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        private bool isLogin;
        public bool IsLogin { get => isLogin; set => isLogin = value; }

        public LoginViewModel()
        {
            LogInCommand = new RelayCommand<Views.LoginWindow>((parameter) => true, (parameter) => Login(parameter));
            PasswordChangedCommand = new RelayCommand<PasswordBox>((parameter) => true, (parameter) => EncodingPassword(parameter));
            OpenSignUpWindowCommand = new RelayCommand<Window>((parameter) => true, (parameter) => OpenSignUpWindow(parameter));
        }
        public void Login(LoginWindow parameter)
        {

            List<Account> accounts = AccountDAL.Instance.ConvertDataTableToList();
            if (string.IsNullOrEmpty(parameter.txtUsername.Text))
            {
                MessageBox.Show("Hay nhap ten dang nhap");
                parameter.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(parameter.txtPassword.Password.ToString()))

            {
                MessageBox.Show("hay nhap mat khau");
                parameter.txtPassword.Focus();
                return;
            }
            int flag = 0;
            foreach (var account in accounts)
            {
                isLogin = false;
                if (account.UserName == this.UserName && account.Password == this.Password)
                {
                    CurrentAccount.UserRole = account.UserRole;
                    CurrentAccount.Email = account.Email;
                    CurrentAccount.Address = account.Address;
                    CurrentAccount.Phone = account.Phone;
                    CurrentAccount.idAccount = account.idAccount;
                    CurrentAccount.Password = account.Password;
                    MessageBox.Show("Dang nhap thanh cong");
                    flag = 1;
                    isLogin = true;
                    break;

                }

            }
            if (flag == 0)
            {
                MessageBox.Show("tai khoan hoac mat khau khong dung");
                parameter.txtUsername.Focus();
                parameter.txtPassword.Focus();
            }
            if (isLogin == true && CurrentAccount.UserRole == "1")
            {
                MainWindow home = new MainWindow();
                // parameter.Hide();
                home.ShowDialog();

                parameter.Show();
            }
            else if (isLogin == true && CurrentAccount.UserRole == "0")
            {
                StaffMainWindow home = new StaffMainWindow();
                // parameter.Hide();
                home.ShowDialog();

                parameter.Show();
            }
        }

        public void EncodingPassword(PasswordBox parameter)
        {
            this.password = parameter.Password;
          //  this.password = MD5Hash(this.password);
        }
        public void OpenSignUpWindow(Window parameter)
        {
            SignUpWindow signUp = new SignUpWindow();
            signUp.txtUsername.Text = null;
            parameter.Opacity = 0.5;
            parameter.WindowStyle = WindowStyle.None;
            signUp.ShowDialog();
            parameter.WindowStyle = WindowStyle.SingleBorderWindow;
            parameter.Opacity = 1;
            parameter.Show();
        }
    }
}
