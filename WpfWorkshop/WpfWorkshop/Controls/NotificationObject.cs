using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfWorkshop.Controls
{
    /// <summary>The notification object.</summary>
    public abstract class NotificationObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>The property changing.</summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>Gets or sets a value indicating whether is change disallowed.</summary>
        protected bool IsChangeDisallowed { get; set; }

        /// <summary>Checks if a property already matches a desired value. Sets the property and
        /// notifies listeners only when necessary.</summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="raiseOnChangingEvent">The notify On Changing.</param>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, bool raiseOnChangingEvent = false, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            if (raiseOnChangingEvent)
            {
                this.IsChangeDisallowed = false;
                this.RaisePropertyChanging(propertyName);
                if (this.IsChangeDisallowed)
                {
                    return false;
                }
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>The set property.</summary>
        /// <param name="storage">The storage.</param>
        /// <param name="value">The value.</param>
        /// <param name="onChanged">The on changed.</param>
        /// <param name="raiseOnChangingEvent">The notify On Changing.</param>
        /// <param name="propertyName">The property name.</param>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The <see cref="bool"/>.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, bool raiseOnChangingEvent = false, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            if (raiseOnChangingEvent)
            {
                this.IsChangeDisallowed = false;
                this.RaisePropertyChanging(propertyName);
                if (this.IsChangeDisallowed)
                {
                    return false;
                }
            }

            storage = value;
            onChanged?.Invoke();
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>Raises this object's PropertyChanged event.</summary>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Raises this object's PropertyChanged event.</summary>
        /// <param name="args">The PropertyChangedEventArgs.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            this.PropertyChanged?.Invoke(this, args);
        }

        /// <summary>Raises this object's PropertyChanged event.</summary>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void RaisePropertyChanging([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanging(new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>Raises this object's PropertyChanged event.</summary>
        /// <param name="args">The PropertyChangedEventArgs.</param>
        protected virtual void OnPropertyChanging(PropertyChangingEventArgs args)
        {
            this.PropertyChanging?.Invoke(this, args);
        }
    }
}
