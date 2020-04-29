using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowsApp.ViewModels.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected PropChange SetField<T>(ref T field, T value,
                                         Action onSuccess = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return new PropChange(null);
            field = value;
            onSuccess?.Invoke();
            OnPropertyChanged(propertyName);
            return new PropChange(this);
        }

        protected PropChange SetProp<T>(Func<T> getter, Action<T> setter, T value,
                                        Action onSuccess = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(getter(), value)) return new PropChange(null);
            setter(value);
            onSuccess?.Invoke();
            OnPropertyChanged(propertyName);
            return new PropChange(this);
        }
    }
}