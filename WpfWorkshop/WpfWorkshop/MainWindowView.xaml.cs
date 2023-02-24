using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfWorkshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window, IMouse
    {
        public MainWindowView()
        {
            InitializeComponent();
            this.Loaded += MainWindowView_Loaded;
            this.MouseMove += MainWindowView_MouseMove;
        }

        private void MainWindowView_MouseMove(object sender, MouseEventArgs e)
        {
            //txtBox.Text = e.GetPosition(this).ToString();
            OnMouseMove(e);
        }

        private void MainWindowView_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel vm = DataContext as MainWindowViewModel;

            var toolbar = this.ToolsGrid;

            var footerComponents = vm.Components;
            int columnIndex = 0;

            foreach (var component in footerComponents)
            {
                var gridCol = new ColumnDefinition() { Width = GridLength.Auto };
                toolbar.ColumnDefinitions.Add(gridCol);
                Grid.SetColumn(component.UIElement, columnIndex++);
                toolbar.Children.Add(component.UIElement);
            }
        }
    }
}
