using System.Windows;
using System.Windows.Controls;

namespace WpfWorkshop.Modules
{
    internal interface IUIComponent
    {
        Control UIElement { get; }
    }

    public class UIComponent : IUIComponent
    {
        public UIComponent(Control uIElement)
        {
            UIElement = uIElement;
        }

        public Control UIElement { get; }
    }
}
