using System.Collections.Generic;
using System.Threading.Tasks;
using WolfBurger.CustomerApp.Model;

namespace WolfBurger.CustomerApp.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>?> LoadAsync();
    }
}