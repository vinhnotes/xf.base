using System.Collections;
using System.Windows.Input;
using BaseProject.Commons.Commands;

namespace BaseProject.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private ICollection _items;
        public ICollection Items
        {
            set { SetProperty(ref _items, value); }
            get { return _items; }
        }

        public virtual void LoadMoreData()
        {

        }

        public ICommand LoadMoreCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LoadMoreData();
                });
            }
        }
    }
}

