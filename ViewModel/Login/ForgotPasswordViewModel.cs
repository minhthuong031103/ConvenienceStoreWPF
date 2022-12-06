﻿using ConvenienceStore.Utils.DataLayerAccess;
using ConvenienceStore.ViewModel.Admin;
using ConvenienceStore.Views.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace ConvenienceStore.ViewModel.Login
{
    public class ForgotPasswordViewModel:BaseViewModel
    {
        public ICommand ForgotPasswordCommand { get; set; }

        public ForgotPasswordViewModel()
        {
            ForgotPasswordCommand = new RelayCommand<ForgotPasswordWindow>(parameter => true,parameter=> Forgot(parameter));
        }
        public void Forgot(ForgotPasswordWindow parameter)
        {
            string cs = @ConfigurationManager.ConnectionStrings["Default"].ToString();
            string query = "select* from Users where Email=" + "\'"+parameter.textEmail.Text.ToString() + "\'";
            
            SqlConnection con = new SqlConnection(cs);
            con.Close(); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows==true)
            {
                reader.Read();
                string email = reader["Email"].ToString();
                string password = reader["Password"].ToString();
               
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("minhku031103@gmail.com", "dajdjblvivpigbvq");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("minhku031103@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Your password";
                mail.Body = "Mật khẩu của bạn là: " + password;
                client.Send(mail);
            }
            else
            {
                MessageBox.Show("email khong ton tai");
            }
        }

    }
}
