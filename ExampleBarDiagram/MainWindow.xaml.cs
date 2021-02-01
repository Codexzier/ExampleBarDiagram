using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ExampleBarDiagram.Annotations;
using ExampleBarDiagram.Diagram;

namespace ExampleBarDiagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

    public class ButtonCommandCreateNewListWithValues : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public ButtonCommandCreateNewListWithValues(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var r = new Random(DateTime.Now.Millisecond);

            var list = new List<DiagramLevelItem>();
            for (int i = 0; i < 20; i++)
            {
                var value = r.NextDouble() * 100;
                var diagramLevelItem = new DiagramLevelItem{ Value = value, ToolTipText = $"Bar item: {i}, Value: {value}"};

                list.Add(diagramLevelItem);
            }

            this._viewModel.Items = list;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<DiagramLevelItem> _items;
        private ICommand _commandCreateNewListWithValues;

        public List<DiagramLevelItem> Items
        {
            get => this._items;
            set
            {
                if (!Equals(value, this._items))
                {
                    this._items = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ICommand CommandCreateNewListWithValues
        {
            get => this._commandCreateNewListWithValues;
            set
            {
                if (Equals(value, this._commandCreateNewListWithValues)) return;
                this._commandCreateNewListWithValues = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
