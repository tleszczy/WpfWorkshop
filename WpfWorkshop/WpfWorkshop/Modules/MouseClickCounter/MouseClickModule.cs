using Autofac;
using WpfWorkshop.Controls;
using WpfWorkshop.Modules.ColorChanger;

namespace WpfWorkshop.Modules.MouseClickCounter
{
    internal class MouseClickModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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

            builder.RegisterType<ColorMediator>().SingleInstance().As<IColorMediator>();
        }
    }
}
