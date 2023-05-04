using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WolfBurger.CustomerApp.Data;
using WolfBurger.CustomerApp.Model;

namespace WolfBurger.CustomerApp.ViewModel
{
    public class CustomerViewModel : ViewModelBased
    {
        private ICustomerDataProvider _customerDataProvider;
        private Customer? selectedCustomer;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = new CustomerDataProvider();
        }

        public ObservableCollection<Customer> Customers { get; set; } = new();

        public Customer? SelectedCustomer 
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
                Customers.Add(customer);
            }
        }

        internal void Add()
        {
            var customer = new Customer() { CustId = 7, FirstName = "New Customer First Name", LastName = "New Customer Last Name", IsDeveloper = true };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

       
    }
}
