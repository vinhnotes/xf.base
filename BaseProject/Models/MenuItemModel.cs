using System;
using System.Windows.Input;
using BaseProject.Commons.Commands;
using BaseProject.Views;
using Xamarin.Forms;

namespace BaseProject.Models
{
    public class MenuItemModel : BaseModel
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string Icon { get; set; }

        public ICommand SelectedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (Title.Equals("Home"))
                    {
                        MainPage.Instance.Detail = new NavigationPage(new HomePage());
                    }
                    else if (Title.Equals("Others"))
                    {
                        MainPage.Instance.Detail = new NavigationPage(new HomePage());
                    }
                    MainPage.Instance.IsPresented = false;
                });
            }
        }

    }
}

