using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WpfWorkshop.Modules;

namespace WpfWorkshop
{
    internal class MainWindowViewModel : Conductor<Screen>.Collection.OneActive
    {
        public MainWindowViewModel(IEnumerable<IUIComponent> components)
        {
            Components = components;
        }

        public IEnumerable<IUIComponent> Components { get; }
    }

    public interface IMouse
    {
        public event MouseEventHandler MouseMove;
        public event MouseButtonEventHandler MouseLeftButtonDown;
    }
}
