using Autofac;
using System.Windows;
using WpfWorkshop.Modules;

namespace WpfWorkshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bootstrapper bootstrapper;

        public App()
        {
            bootstrapper = new Bootstrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            bootstrapper.Configure();

            var mainViewWindow = bootstrapper.container.Resolve<MainWindowView>();
            mainViewWindow.DataContext = bootstrapper.container.Resolve<MainWindowViewModel>();

            bootstrapper.container.Resolve<ModuleBuilder>();

            mainViewWindow.Show();
            //base.OnStartup(e);
        }
    }
}
