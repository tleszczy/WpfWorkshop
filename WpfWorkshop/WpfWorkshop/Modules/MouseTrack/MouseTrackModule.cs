using Autofac;
using WpfWorkshop.Controls;

namespace WpfWorkshop.Modules.MouseTrack
{
    internal class MouseTrackModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MouseTrackViewModel>().As<MouseTrackViewModel>();

            builder.Register((c) =>
            {
                var viewModel = c.Resolve<MouseTrackViewModel>();
                return new SimpleCounter
                {
                    DataContext = viewModel,
                };
            }
            ).As<IComponentGUI>();
        }
    }
}
