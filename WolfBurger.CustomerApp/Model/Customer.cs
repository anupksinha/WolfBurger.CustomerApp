using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfBurger.CustomerApp.Model
{
    public class Customer
    {
        private int _custId;
        private string? _firstName;
        private string? _lastName;
        private bool _isDeveloper;

        public int CustId { get => _custId; set => _custId = value; }
        public string? FirstName { get => _firstName; set => _firstName = value; }
        public string? LastName { get => _lastName; set => _lastName = value; }
        public bool IsDeveloper { get => _isDeveloper; set => _isDeveloper = value; }
    }

}
