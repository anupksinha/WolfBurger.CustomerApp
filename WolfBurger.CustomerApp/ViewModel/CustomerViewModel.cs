using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using WolfBurger.CustomerApp.Command;
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
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

      

        public ObservableCollection<CustomerItemViewModel> Customers { get; set; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecutedChanged();
            }
        }

        public bool IsCustomerSelected 
        { 
            get => SelectedCustomer is not null;
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

        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand MoveNavigationCommand { get; private set; }

        public DelegateCommand DeleteCommand { get; private set; }

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

        private void Add(Object parameter)
        {
            var customer = new Customer() { CustId = 7, FirstName = "New Customer First Name", LastName = "New Customer Last Name", IsDeveloper = true };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        private void MoveNavigation(Object parameter)
        {
            NavigationColumnSide = NavigationColumnSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        private void Delete(Object parameter)
        {
            if( selectedCustomer is not null)
            {
                Customers.Remove(selectedCustomer);
                selectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter)
        {
            return selectedCustomer is not null;
                
        }

        public enum NavigationSide
        {
            Left,
            Right

        }
    }
}
