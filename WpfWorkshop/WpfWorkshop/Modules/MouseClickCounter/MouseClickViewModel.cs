using WpfWorkshop.Controls;

namespace WpfWorkshop.Modules.MouseClickCounter
{
    public class MouseClickViewModel : NotificationObject
    {
        private readonly IMouse mouse;
        private double? patchFramesPerSecond = 1;
        private string label = "lol";

        public MouseClickViewModel(IMouse mouse) 
        {
            this.mouse = mouse;
            this.mouse.MouseMove += (s, e) =>
            {
                FpsValue++;
            };
        }

        public double? FpsValue
        {
            get => this.patchFramesPerSecond;
            set => this.SetProperty(ref this.patchFramesPerSecond, value);
        }

        public string FpsLabel
        {
            get => this.label;
            set => this.SetProperty(ref this.label, value);
        }
    }
}
