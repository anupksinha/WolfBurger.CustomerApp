using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfBurger.CustomerApp.Model;

namespace WolfBurger.CustomerApp.Data
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>?> LoadAsync()
        {
            await Task.Delay(100);
            
            return new Customer[]
            {
                new Customer() {CustId=1, FirstName="Ansh", LastName="Sinha", IsDeveloper=false },
                new Customer() {CustId=2, FirstName="Ben", LastName="Aflec", IsDeveloper=false },
                new Customer() {CustId=3, FirstName="Kenne", LastName="soon", IsDeveloper=false },
                new Customer() {CustId=4, FirstName="Sarthak", LastName="Mishra", IsDeveloper=true },
                new Customer() {CustId=5, FirstName="Sophie", LastName="Staalwart", IsDeveloper=true },
            };
        }
    }
}
