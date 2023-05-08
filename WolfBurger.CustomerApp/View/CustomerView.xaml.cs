using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WolfBurger.CustomerApp.Data;
using WolfBurger.CustomerApp.ViewModel;

namespace WolfBurger.CustomerApp.View
{
    public partial class CustomerView : UserControl
    {
        CustomerViewModel _customerViewModel;
        public CustomerView()
        {
            InitializeComponent();
            _customerViewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _customerViewModel;
            Loaded += CustomerView_LoadedAsync;
        }

        private async void CustomerView_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await _customerViewModel.LoadAsync();
        }
    }
}
