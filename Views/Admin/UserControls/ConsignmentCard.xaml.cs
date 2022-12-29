﻿using ConvenienceStore.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvenienceStore.Views.Admin.UserControls
{
    /// <summary>
    /// Interaction logic for ConsignmentCard.xaml
    /// </summary>
    public partial class ConsignmentCard : UserControl
    {
        public ConsignmentCard()
        {
            InitializeComponent();
        }

        public Product ProductItem
        {
            get { return (Product)GetValue(ProductItemProperty); }
            set { SetValue(ProductItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductItemProperty =
            DependencyProperty.Register("ProductItem", typeof(Product), typeof(ConsignmentCard), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ConsignmentCard productCardControl)
            {
                productCardControl.DataContext = productCardControl.ProductItem;
            }
        }
    }
}