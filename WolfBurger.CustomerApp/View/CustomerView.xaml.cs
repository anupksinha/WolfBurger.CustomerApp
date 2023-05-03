using System.Windows;
using System.Windows.Controls;

namespace WolfBurger.CustomerApp.View
{
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }
        private void MoveNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            //var column = (int)CustomerListGrid.GetValue(Grid.ColumnProperty);
            //var newColumn = column == 0 ? 2 : 0;
            //CustomerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            var column = Grid.GetColumn(CustomerListGrid);
            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(CustomerListGrid, newColumn);
        }
    }
}
