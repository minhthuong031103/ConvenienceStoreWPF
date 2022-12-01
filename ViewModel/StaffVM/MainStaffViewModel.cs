﻿using ConvenienceStore.Views.Staff.ProductWindow;
using ConvenienceStore.Views.Staff.TroubleWindow;
using ConvenienceStore.Views.Staff.VoucherWindow;
using ConvenienceStore.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ConvenienceStore.ViewModel.MainBase;

namespace ConvenienceStore.ViewModel.StaffVM
{
    public partial class MainStaffViewModel : BaseViewModel
    {
        public static User? StaffCurrent { get; set; }
        public ICommand? EmployeeCommand { get; set; }
        public ICommand? ProductCommand { get; set; }
        public ICommand? VoucherCommand { get; set; }
        public ICommand? ReportCommand { get; set; }
        public ICommand? ShowPanelCommand { get; set; }
        public ICommand? HidePanelCommand { get; set; }
        public ICommand? CloseWindowCommand { get; set; }
        public ICommand? MinimizeWindowCommand { get; set; }
        public ICommand? MouseMoveWindowCommand { get; set; }
        public ICommand? MaximizeWindowCommand { get; set; }

        public static Grid MaskName { get; set; }

        #region commands
        public ICommand CloseMainStaffWindowCM { get; set; }
        public ICommand MinimizeMainStaffWindowCM { get; set; }
        public ICommand MouseMoveWindowCM { get; set; }
        public ICommand LoadMovieScheduleWindow { get; set; }
        public ICommand LoadFoodPageCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand SelectedGenreCM { get; set; }
        public ICommand SelectedDateCM { get; set; }
        public ICommand LoadErrorPageCM { get; set; }
        public ICommand SignoutCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand ChangeRoleCM { get; set; }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { _IsLoading = value; OnPropertyChanged(); }
        }

        private bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; OnPropertyChanged(); }
        }


        #endregion
        public MainStaffViewModel()
        {

            ProductCommand = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Content = new ProductPage();
            });
            VoucherCommand = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Content = new VoucherPage();

            });
            ReportCommand = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Content = new TroublePage();

            });

            CloseWindowCommand = new RelayCommand<Grid>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window w = Window.GetWindow(p);
                w.Close();
            });

            MinimizeWindowCommand = new RelayCommand<Grid>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window w = Window.GetWindow(p);
                if (w.WindowState != WindowState.Minimized)
                    w.WindowState = WindowState.Minimized;
                else
                    w.WindowState = WindowState.Normal;
            });
            MaximizeWindowCommand = new RelayCommand<Grid>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window w = Window.GetWindow(p);
                if (w.WindowState != WindowState.Maximized)
                    w.WindowState = WindowState.Maximized;
                else
                    w.WindowState = WindowState.Normal;
            });
            MouseMoveWindowCommand = new RelayCommand<Grid>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window w = Window.GetWindow(p);
                w.DragMove();
            }
           );
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });

        }
    }
}
//LoadShowtimeDataCM = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
// {
//     p.SelectedIndex = -1;
//     await LoadShowtimeData();
// });
//LoadErrorPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
// {
//     p.Content = new TroublePage();
// });
//SignoutCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
//{
//    p.Hide();
//    LoginWindow w1 = new LoginWindow();
//    w1.ShowDialog();
//    p.Close();
//});

//ChangeRoleCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
//{
//    p.Hide();
//    MainAdminWindow w1 = new MainAdminWindow();
//    MainAdminViewModel.currentStaff = CurrentStaff;
//    w1.CurrentUserName.Content = CurrentStaff.Name;
//    w1.Show();
//    p.Close();
//});