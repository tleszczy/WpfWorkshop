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
    /// Interaction logic for Counter.xaml
    /// </summary>
    public partial class Counter : UserControl, IComponentGUI
    {
        /// <summary>The dependency property backing the <see cref="FpsLabel"/> property.</summary>
        public static readonly DependencyProperty FpsLabelProperty =
            DependencyProperty.Register(nameof(FpsLabel), typeof(string), typeof(Counter), new PropertyMetadata(null));

        /// <summary>The dependency property backing the <see cref="FpsValue"/> property.</summary>
        public static readonly DependencyProperty FpsValueProperty =
            DependencyProperty.Register(nameof(FpsValue), typeof(double), typeof(Counter), new PropertyMetadata(double.NaN));

        public Counter()
        {
            InitializeComponent();
        }

        /// <summary>Gets or sets the text to display next to the frames per second number.</summary>
        public string FpsLabel
        {
            get => (string)this.GetValue(FpsLabelProperty);
            set => this.SetValue(FpsLabelProperty, value);
        }

        /// <summary>Gets or sets the number of frames per second to display.</summary>
        public double FpsValue
        {
            get => (double)this.GetValue(FpsValueProperty);
            set => this.SetValue(FpsValueProperty, value);
        }

        public Control Control => this;
    }
}
