using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using BaseProject.Apps;
using BaseProject.Commons.Commands;
using BaseProject.Models;
using BaseProject.Commons.Extensions;
using BaseProject.Views;
using Xamarin.Forms;

namespace BaseProject.ViewModels
{
    public class HomeViewModel : ListViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
            Items = new ObservableCollection<Repos>();
            LoadData();
        }

        public ICommand LoadItemsCommand
        {
            get
            {
                return new DelegateCommand(() => LoadData());
            }
        }

        public void LoadData()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            ServiceManager.GetData<Response<List<Repos>>>(string.Format("GetListRepos:{0}", Items.Count), Apis.Instance.MostRepoApi(0, Constants.ListViewPageLimit),
               (response) =>
               {
                   if (response != null)
                   {
                       if (response.Items != null)
                       {
                        (Items as ObservableCollection<Repos>).Add(response.Items);
                       }
                   }
            });

        }

        public override void LoadMoreData()
        {
            base.LoadMoreData();
            if (IsBusy)
                return;

            IsBusy = true;

            ServiceManager.GetData<Response<List<Repos>>>(string.Format("GetListRepos:{0}", Items.Count), Apis.Instance.MostRepoApi((int)Items.Count/Constants.ListViewPageLimit, Constants.ListViewPageLimit),
               (response) =>
               {
                   if (response != null)
                   {
                       if (response.Items != null)
                       {
                           (Items as ObservableCollection<Repos>).Add(response.Items);
                       }
                   }
               });

        }

        public ICommand GotoSearch
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MainPage.Instance.Detail.Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
                });
            }
        }
    }
}
