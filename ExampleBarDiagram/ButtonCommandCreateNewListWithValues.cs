using System;
using System.Collections.Generic;
using System.Windows.Input;
using ExampleBarDiagram.Diagram;

namespace ExampleBarDiagram
{
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
}