using System.Windows;

namespace ExampleBarDiagram
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var viewModel = (MainWindowViewModel) this.DataContext;
            viewModel.CommandCreateNewListWithValues = new ButtonCommandCreateNewListWithValues(viewModel);
        }
    }
}
