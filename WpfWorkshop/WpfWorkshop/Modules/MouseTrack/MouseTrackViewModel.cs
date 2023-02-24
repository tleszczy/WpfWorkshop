using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfWorkshop.Controls;

namespace WpfWorkshop.Modules.MouseTrack
{
    internal class MouseTrackViewModel : NotificationObject
    {
        private readonly IMouse mouse;
        private double? patchFramesPerSecond = 1;
        private string label = "Mouse track";
        private Color colorPickerColor = Colors.Black;

        public MouseTrackViewModel(IMouse mouse)
        {
            this.mouse = mouse;

            this.mouse.MouseMove += (s, e) =>
            {
                Value++;
            };
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
