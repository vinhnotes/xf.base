using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BaseProject.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainPage.Instance.IsGestureEnabled = false;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainPage.Instance.IsGestureEnabled = true;
        }
    }
}
