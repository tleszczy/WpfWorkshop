using System.Collections.Generic;
using WpfWorkshop.Modules;

namespace WpfWorkshop
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel(IEnumerable<IUIComponent> components)
        {
            Components = components;
        }

        public IEnumerable<IUIComponent> Components { get; }
    }
}
