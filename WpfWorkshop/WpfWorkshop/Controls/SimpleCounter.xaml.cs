using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWorkshop.Controls
{
    public interface IComponentGUI
    {
        Control Control { get; }
    }

    /// <summary>
    /// Interaction logic for SimpleCounter.xaml
    /// </summary>
    public partial class SimpleCounter : UserControl, IComponentGUI
    {
        public SimpleCounter()
        {
            InitializeComponent();
        }

        public Control Control => this;
    }
}
