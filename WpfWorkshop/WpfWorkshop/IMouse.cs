using System;
using System.Windows.Input;

namespace WpfWorkshop
{
    public interface IMouse
    {
        event MouseEventHandler MouseMove;        
        event MouseButtonEventHandler MouseLeftButtonDown;
        event MouseButtonEventHandler MouseRightButtonDown;
    }
}
