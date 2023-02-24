using System;
using System.Windows.Media;

namespace WpfWorkshop.Modules.ColorChanger
{
    public class ColorMediator : IColorMediator
    {
        private Color color = Colors.Black;

        public Color Color => this.color;

        public event EventHandler ColorChanged;

        public void SetColor(Color color)
        {
            this.color = color;
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
