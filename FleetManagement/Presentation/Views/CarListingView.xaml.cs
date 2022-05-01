﻿using Microsoft.Extensions.DependencyInjection;
using Presentation.ViewModels;
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

namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for CarListingView.xaml
    /// </summary>
    public partial class CarListingView : UserControl
    {
        public CarListingView()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService<CarListingViewModel>();
        }
    }
}
