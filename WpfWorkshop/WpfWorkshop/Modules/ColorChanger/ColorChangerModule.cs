using Autofac;

namespace WpfWorkshop.Modules.ColorChanger
{
    public class ColorChangerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType<ColorChangerOnClick>().As<ICustomModule>();
        }
    }
}
