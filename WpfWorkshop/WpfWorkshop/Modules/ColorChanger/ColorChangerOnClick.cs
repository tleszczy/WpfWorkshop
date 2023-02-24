using System;
using System.Windows.Media;

namespace WpfWorkshop.Modules.ColorChanger
{
    public class ColorChangerOnClick : ICustomModule
    {
        private readonly IMouse mouse;
        private readonly IColorMediator colorMediator;

        public ColorChangerOnClick(IMouse mouse, IColorMediator colorMediator)
        {
            this.mouse = mouse;
            this.colorMediator = colorMediator;

            this.mouse.MouseRightButtonDown += Mouse_MouseRightButtonDown;
        }

        private void Mouse_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            colorMediator.SetColor(GetRandomColor());
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            var color = Color.FromRgb(
                    (byte)random.Next(255),
                    (byte)random.Next(255),
                    (byte)random.Next(255)
                    );
            return color;
        }
    }
}
