using System.Threading.Tasks;
using System.Windows;
using WolfBurger.CustomerApp.Data;
using WolfBurger.CustomerApp.ViewModel;

namespace WolfBurger.CustomerApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(new CustomerViewModel(new CustomerDataProvider()));
            DataContext = _viewModel;
            Loaded += MainWindow_LoadedAsync;
                
        }

        private async void MainWindow_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
