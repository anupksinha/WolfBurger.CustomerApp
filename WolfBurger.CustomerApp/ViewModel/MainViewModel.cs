using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfBurger.CustomerApp.Command;

namespace WolfBurger.CustomerApp.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private readonly CustomerViewModel _customerViewModel;
        private readonly ProductViewModel _productViewModel;
        private ViewModelBase? _selectedViewModel;
        public MainViewModel(CustomerViewModel customerViewModel, ProductViewModel productViewModel)
        {
            _customerViewModel = customerViewModel;
            _productViewModel = productViewModel;
            SelectedViewModel = _productViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public ViewModelBase? SelectedViewModel
		{
			get => _selectedViewModel;

			set 
			{ 
				_selectedViewModel = value;
				RaisePropertyChanged();
			}
		}

        public DelegateCommand SelectViewModelCommand { get;  }
        private async void SelectViewModel(Object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();

        }

        public async override Task LoadAsync()
        {
            if(SelectedViewModel is not null) 
            {
                await SelectedViewModel.LoadAsync();
            }
        }



    }
}
