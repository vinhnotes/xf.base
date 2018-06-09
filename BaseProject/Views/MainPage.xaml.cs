using System.Collections.Generic;
using Xamarin.Forms;
using System;

using BaseProject.Views;
using BaseProject.Models;

namespace BaseProject
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MenuItemModel> MainMenuItems { get; set; }
        public static MainPage Instance;

        public MainPage()
        {
            this.Detail = new NavigationPage(new HomePage());

            InitializeComponent();
            Instance = this;
        }

    }
}
