using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using WpfWorkshop.Controls;
using WpfWorkshop.Modules;

namespace WpfWorkshop
{
    internal class Bootstrapper
    {
        public IContainer container;

        public void Configure()
        {
            var builder = new ContainerBuilder();

            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
            builder.RegisterType<ModuleBuilder>();

            builder.RegisterType<MainWindowViewModel>();

            builder.RegisterAdapter<IComponentGUI, IUIComponent>((cc, gui) => new UIComponent(gui.Control));

            builder.RegisterType<MainWindowView>().AsSelf().SingleInstance().AsImplementedInterfaces();
            container = builder.Build();
        }
    }
}
