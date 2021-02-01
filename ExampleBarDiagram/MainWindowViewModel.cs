using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExampleBarDiagram.Annotations;
using ExampleBarDiagram.Diagram;

namespace ExampleBarDiagram
{
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