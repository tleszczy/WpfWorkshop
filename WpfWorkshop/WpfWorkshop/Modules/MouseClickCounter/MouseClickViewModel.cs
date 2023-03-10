using System.Windows.Media;
using WpfWorkshop.Controls;
using WpfWorkshop.Modules.ColorChanger;

namespace WpfWorkshop.Modules.MouseClickCounter
{
    public class MouseClickViewModel : NotificationObject
    {
        private readonly IMouse mouse;
        private readonly IColorMediator colorMediator;
        private double? patchFramesPerSecond = 1;
        private string label = "Click counter";
        private Color colorPickerColor = Colors.Black;

        public MouseClickViewModel(IMouse mouse, IColorMediator colorMediator)
        {
            this.mouse = mouse;
            this.colorMediator = colorMediator;
            this.colorMediator.ColorChanged += ColorMediator_ColorChanged;

            this.mouse.MouseLeftButtonDown += (s, e) =>
            {
                Value++;
            };
        }

        private void ColorMediator_ColorChanged(object? sender, System.EventArgs e)
        {
            BackgroundColor = this.colorMediator.Color;
        }

        public double? Value
        {
            get => this.patchFramesPerSecond;
            set => this.SetProperty(ref this.patchFramesPerSecond, value);
        }

        public string Label
        {
            get => this.label;
            set => this.SetProperty(ref this.label, value);
        }

        public Color BackgroundColor
        {
            get => this.colorPickerColor;
            set => this.SetProperty(ref this.colorPickerColor, value);
        }
    }
}
