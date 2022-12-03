﻿using ConvenienceStore.ViewModel.Admin.AdminVM;
using ConvenienceStore.Views.Admin;
using System.Windows.Input;

namespace ConvenienceStore.ViewModel.Admin
{
    public class AdminMainViewModel : BaseViewModel
    {
        private double wdHeight_ = 660;
        private double wdWidth_ = 1200;
        public double wdWidth
        {
            get { return wdWidth_; }
            set { wdWidth_ = value; OnPropertyChanged(); }
        }
        public double wdHeight
        {
            get { return wdHeight_; }
            set { wdHeight_ = value; OnPropertyChanged(); }
        }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        private int _isPanelVisible;
        public int IsPanelVisible
        {
            get { return _isPanelVisible; }
            set { _isPanelVisible = value; OnPropertyChanged(); }
        }
        private double _opacityChange;
        public double OpacityChange
        {
            get { return _opacityChange; }
            set { _opacityChange = value; OnPropertyChanged(); }
        }
        private double _opacityChange1;
        public double OpacityChange1
        {
            get { return _opacityChange1; }
            set { _opacityChange1 = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand EmployeeCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand ShowPanelCommand { get; set; }
        public ICommand HidePanelCommand { get; set; }
        public ICommand SizeChangedCommand { get; set; }

        public AdminMainViewModel()
        {
            IsPanelVisible = 0;  //moi vo la no ko mo menu =hidden
            OpacityChange = 1;
            OpacityChange1 = 0.9;
            CurrentView = new InputInfoVM();
            ShowPanelCommand = new RelayCommand<AdminMainWindow>(parameter => true, parameter => Show(parameter));
            HidePanelCommand = new RelayCommand<AdminMainWindow>(parameter => true, parameter => Hide(parameter));
            SizeChangedCommand = new RelayCommand<AdminMainWindow>(parameter => true, parameter => SizeChanged(parameter));
        }

        public void Show(AdminMainWindow parameter)
        {

            IsPanelVisible = 1;
            OpacityChange = 0.6;
            OpacityChange1 = 0.2;
        }
        public void Hide(AdminMainWindow parameter)
        {
            IsPanelVisible = 2; //Hidden
            OpacityChange = 1;
            OpacityChange1 = 0.9;
        }

        
        public void SizeChanged(AdminMainWindow parameter)
        {
            wdHeight = parameter.ActualHeight;
            wdWidth = parameter.ActualWidth;



        }

    }
}
