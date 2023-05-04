using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WolfBurger.CustomerApp.ViewModel
{
    public class ViewModelBase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] String? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
