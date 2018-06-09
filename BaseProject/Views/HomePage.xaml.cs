using System;
using System.Collections.Generic;

using Xamarin.Forms;

using BaseProject.ViewModels;
using Xamarin.Forms.Xaml;

namespace BaseProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel();
        }
    }
}
