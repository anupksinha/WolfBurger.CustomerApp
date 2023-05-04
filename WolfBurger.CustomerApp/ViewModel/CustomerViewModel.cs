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

       
    }
}
