using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WolfBurger.CustomerApp.Data;
using WolfBurger.CustomerApp.Model;

namespace WolfBurger.CustomerApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = new CustomerDataProvider();
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; set; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
            }
        }

        public NavigationSide NavigationColumnSide 
        { 
            get => _navigationSide;
            set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
         }
        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.LoadAsync();
            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }

        internal void Add()
        {
            var customer = new Customer() { CustId = 7, FirstName = "New Customer First Name", LastName = "New Customer Last Name", IsDeveloper = true };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        internal void MoveNavigation()
        {
            NavigationColumnSide = NavigationColumnSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        public enum NavigationSide
        {
            Left,
            Right

        }
    }
}
