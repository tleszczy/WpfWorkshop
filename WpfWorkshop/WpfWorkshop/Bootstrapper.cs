using Autofac;
using Autofac.Configuration;
using Caliburn.Micro;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfWorkshop
{
    internal class Bootstrapper : BootstrapperBase
    {
        private const string ModuleFilePrefix = "WpfWorkshop";
        private IContainer container;

        protected override void BuildUp(object instance)
        {
            container.InjectProperties(instance);
            base.BuildUp(instance);
        }

        protected override void Configure()
        {
            base.Configure();
            var builder = new ContainerBuilder();

            var config = new ConfigurationBuilder();
            // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
            // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
            config.AddJsonFile("autofac.json");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            RegisterClass<MainWindowViewModel>(builder);
            RegisterTypes(builder);
            container = builder.Build();
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
        }

        private static void RegisterClass<T>(ContainerBuilder builder)
        {
            builder.RegisterType<T>().SingleInstance();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MainWindowViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return key == null ? container.Resolve(service) : container.ResolveKeyed(key, service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var enumerableOfServiceType = typeof(IEnumerable<>).MakeGenericType(service);
            return (IEnumerable<object>)container.Resolve(enumerableOfServiceType);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return GetAllDllEntries().Select(Assembly.LoadFrom);
        }

        private static string[] GetAllDllEntries()
        {
            var runtimeDir = AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(runtimeDir).Where(file => Regex.IsMatch(file, @"^.+\.(dll)$")).Where(x =>
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(x);
                return fileNameWithoutExtension.StartsWith(ModuleFilePrefix, StringComparison.Ordinal);
            }).ToArray();

            return files;
        }
    }
}
