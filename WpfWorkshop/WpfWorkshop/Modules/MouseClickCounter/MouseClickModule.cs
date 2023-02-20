using Autofac;
using System.Windows.Data;
using WpfWorkshop.Controls;

namespace WpfWorkshop.Modules.MouseClickCounter
{
    internal class MouseClickModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.RegisterType<Counter>()
                .As<IComponentGUI>()
                //.WithProperty("DataContext", new MouseClickViewModel())                
                .OnActivating(c =>
                {
                    c.Instance.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                    c.Instance.FpsLabel = "Labelka";
                    c.Instance.FontSize = 30;

                    var binding = new Binding("PatchFramesPerSecond")
                    {
                        Mode = BindingMode.OneWay,
                        Source = c.Instance.DataContext,
                    };

                    c.Instance.SetBinding(Counter.FpsValueProperty, binding);
                }); */

            builder.RegisterType<MouseClickViewModel>();

            builder.Register((c) =>
            {
                var viewModel = c.Resolve<MouseClickViewModel>();
                return new SimpleCounter
                {
                    DataContext = viewModel,
                };
            }
            ).As<IComponentGUI>();            

            builder.RegisterAdapter<IComponentGUI, IUIComponent>((cc, gui) => new UIComponent(gui.Control));
        }
    }
}
