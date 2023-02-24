using System;
using System.Windows.Media;

namespace WpfWorkshop.Modules.ColorChanger
{
    public interface IColorMediator
    {
        event EventHandler ColorChanged;
        void SetColor(Color color);
        Color Color { get; }
    }
}