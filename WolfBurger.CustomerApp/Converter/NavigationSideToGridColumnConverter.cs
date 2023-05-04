using System;
using System.Globalization;
using System.Windows.Data;
using static WolfBurger.CustomerApp.ViewModel.CustomerViewModel;

namespace WolfBurger.CustomerApp.Converter
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var NavigationSide = (NavigationSide)value;
            return NavigationSide == NavigationSide.Left
                ? 0  //Right
                : 2;  //right
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
