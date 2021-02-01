using System.Windows;

namespace ExampleBarDiagram
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            this.InitializeComponent();

            this._viewModel = (MainWindowViewModel) this.DataContext;
            this._viewModel.CommandCreateNewListWithValues = new ButtonCommandCreateNewListWithValues(this._viewModel);
        }
    }
}
