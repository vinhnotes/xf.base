using System;

using Xamarin.Forms;
using BaseProject.Views;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using BaseProject.Models;
using System.Diagnostics;

namespace BaseProject.ViewModels
{
    public class MainViewModel : ListViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<MenuItemModel>();
            LoadData();
        }

        public void LoadData()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                (Items as ObservableCollection<MenuItemModel>).Clear();
                var mainMenuItems = new List<MenuItemModel>()
                {
                    new MenuItemModel() { Title = "Home", Icon = "HomeIcon.png", TargetType = typeof(HomePage) },
                    new MenuItemModel() { Title = "Others", Icon = "OthersIcon.png", TargetType = typeof(HomePage) }
                };
                foreach (var item in mainMenuItems)
                {
                    (Items as ObservableCollection<MenuItemModel>).Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

