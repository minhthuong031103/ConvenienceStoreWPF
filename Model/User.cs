//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConvenienceStore.Model
{
    using ConvenienceStore.ViewModel.MainBase;
    using System;
    using System.Collections.Generic;
    public partial class User : BaseViewModel
    {
        public int _Id { get; set; } public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        public string _UserRole; public string UserRole { get => _UserRole; set { _UserRole = value; OnPropertyChanged(); } }
        public string _Name; public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        public string? _Address; public string? Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        public string _Phone; public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        public string? _Email; public string? Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        public string _UserName; public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        public string _Password; public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private Byte[] _Image; public Byte[] Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }

    }
}