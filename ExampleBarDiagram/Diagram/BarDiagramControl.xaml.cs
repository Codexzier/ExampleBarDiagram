using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ExampleBarDiagram.Diagram
{
    public partial class BarDiagramControl
    {
        public List<DiagramLevelItem> DiagramLevelItemsSource
        {
            get => (List<DiagramLevelItem>)this.GetValue(DiagramLevelItemsSourceProperty);
            set => this.SetValue(DiagramLevelItemsSourceProperty, value);
        }

        public static readonly DependencyProperty DiagramLevelItemsSourceProperty =
            DependencyProperty.RegisterAttached("DiagramLevelItemsSource",
                typeof(List<DiagramLevelItem>),
                typeof(BarDiagramControl),
                new PropertyMetadata(new List<DiagramLevelItem>(), UpdateDiagram));

        private static void UpdateDiagram(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BarDiagramControl control)
            {
                SetValuesToBarDiagram(control);
            }
        }

        private static void SetValuesToBarDiagram(BarDiagramControl control)
        {
            if (control.DiagramLevelItemsSource == null)
            {
                return;
            }

            control.SimpleDiagram.Children.Clear();

            var heightScale = control.ActualHeight / 100d;

            var widthPerResult = control.ActualWidth / control.DiagramLevelItemsSource.Count;

            foreach (var diagramLevelItem in control.DiagramLevelItemsSource)
            {
                var heightValue = diagramLevelItem.Value * heightScale;

                var barItem = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.DarkGreen),
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Width = widthPerResult,
                    Height = heightValue,
                    ToolTip = diagramLevelItem.ToolTipText
                };

                control.SimpleDiagram.Children.Add(barItem);
            }
        }

        public BarDiagramControl() => this.InitializeComponent();

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e) => SetValuesToBarDiagram(this);
    }
}
