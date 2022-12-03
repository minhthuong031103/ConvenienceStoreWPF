﻿using ConvenienceStore.Model.Admin;
using ConvenienceStore.Utils.Helpers;
using ConvenienceStore.ViewModel.Admin.Command.InputInfoCommand;
using ConvenienceStore.ViewModel.Admin.Command.ProductCommand;
using ConvenienceStore.ViewModel.Admin.Command.ProductCommand.AddNewProductCommand;
using ConvenienceStore.ViewModel.Admin.Command.ProductCommand.ProductCardCommand;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ConvenienceStore.ViewModel.Admin.AdminVM
{
    public class InputInfoVM : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<Manager> managers { get; set; }
        public List<InputInfo> inputInfos { get; set; }
        public ObservableCollection<InputInfo> ObservableInputInfos { get; set; }

        private int isDesc;

        public int IsDesc
        {

            get { return isDesc; }
            set
            {
                isDesc = value;
                OnPropertyChanged("IsDesc");

                OrderByInputDate();
            }
        }


        private Manager selectedManager;
        public Manager SelectedManager
        {

            get { return selectedManager; }
            set
            {
                selectedManager = value;
                OnPropertyChanged("SelectedManager");

                if (selectedManager != null)
                {
                    SetInputInfosCoresspondManager();
                }
            }
        }


        public List<Supplier> suppliers { get; set; }

        private InputInfo selectedInputInfo;

        public InputInfo SelectedInputInfo
        {
            get { return selectedInputInfo; }
            set
            {
                selectedInputInfo = value;
                OnPropertyChanged("SelectedInputInfo");
            }
        }

        public List<Product> products;

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

        public ObservableCollection<Product> ObservableProducts { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        // Command

        public OpenInputInfoCommand OpenInputInfoCommand { get; set; }
        public AddInputInfoButtonCommand AddInputInfoButtonCommand { get; set; }
        public CreateInputInfoButtonCommand CreateInputInfoButtonCommand { get; set; }
        public DeleteInputInfoCommand DeleteInputInfoCommand { get; set; }
        public SearchButtonCommand SearchButtonCommand { get; set; }
        public AddProductButtonCommand AddProductButtonCommand { get; set; }
        public DeleteProductCommand DeleteProductCommand { get; set; }
        public SaveNewProductCommand SaveNewProductCommand { get; set; }
        public EditProductButton EditProductButton { get; set; }

        public ICommand SupplierCommand { get; set; }
        public InputInfoVM()
        {
            inputInfos = DatabaseHelper.FetchingInputInfo();
            ObservableInputInfos = new ObservableCollection<InputInfo>();

            IsDesc = 0;

            managers = DatabaseHelper.FetchingManagers();
            managers.Insert(0, new Manager()
            {
                Id = 0,
                Name = "All"
            });

            suppliers = DatabaseHelper.FetchingSupplier();

            products = new List<Product>();
            ObservableProducts = new ObservableCollection<Product>();

            OpenInputInfoCommand = new OpenInputInfoCommand(this);
            AddInputInfoButtonCommand = new AddInputInfoButtonCommand(this);
            CreateInputInfoButtonCommand = new CreateInputInfoButtonCommand(this);
            DeleteInputInfoCommand = new DeleteInputInfoCommand(this);

            SearchButtonCommand = new SearchButtonCommand(this);
            AddProductButtonCommand = new AddProductButtonCommand(this);
            DeleteProductCommand = new DeleteProductCommand(this);
            SaveNewProductCommand = new SaveNewProductCommand(this);

            EditProductButton = new EditProductButton(this);

        }

        public void LoadProducts()
        {
            products = selectedInputInfo.products;

            searchContent = "";
            SetProductsCorrespondSearch();
        }

        public void SetInputInfosCoresspondManager()
        {
            ObservableInputInfos.Clear();

            if (isDesc == 1)
            {
                for (int i = inputInfos.Count - 1; i >= 0; --i)
                {
                    if (inputInfos[i].UserId == selectedManager.Id || selectedManager.Name == "All")
                    {
                        ObservableInputInfos.Add(inputInfos[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < inputInfos.Count; ++i)
                {
                    if (inputInfos[i].UserId == selectedManager.Id || selectedManager.Name == "All")
                    {
                        ObservableInputInfos.Add(inputInfos[i]);
                    }
                }
            }

        }

        public void OrderByInputDate()
        {
            if (isDesc == 1)
            {
                var descInputInfos = ObservableInputInfos.OrderByDescending(e => e.InputDate).ToList();
                ObservableInputInfos.Clear();
                for (int i = 0; i < descInputInfos.Count; ++i)
                {
                    ObservableInputInfos.Add(descInputInfos[i]);
                }
            }
            else
            {
                var ascInputInfos = ObservableInputInfos.OrderBy(e => e.InputDate).ToList();
                ObservableInputInfos.Clear();
                for (int i = 0; i < ascInputInfos.Count; ++i)
                {
                    ObservableInputInfos.Add(ascInputInfos[i]);
                }
            }

        }

        public void SetProductsCorrespondSearch()
        {
            ObservableProducts.Clear();

            for (int i = 0; i < products.Count; ++i)
            {
                if (products[i].Barcode.Contains(searchContent))
                {
                    ObservableProducts.Add(products[i]);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}