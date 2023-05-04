using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WolfBurger.CustomerApp.Data;
using WolfBurger.CustomerApp.Model;

namespace WolfBurger.CustomerApp.ViewModel
{
    public class CustomerViewModel
    {
        private ICustomerDataProvider _customerDataProvider;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = new CustomerDataProvider();
        }

        public ObservableCollection<Customer> Customers { get; set; } = new();

        public Customer? SelectedCustomer { get; set; }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers =await _customerDataProvider.LoadAsync();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
    }
}
