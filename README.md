# ExampleBarDiagram
A small example of how a diagram can be created in WPF.
Mehr informationen zu diesem Beispiel erfährst du auf meinem Blog.

##### English
## Small solution
This time I come here with something relatively simple. The background is that I create my own framework, with which I always give my program the same look. In addition, some controls are created by myself and therefore not used by external providers. After all, it should be for private use.

## What shows the solution
Building a reusable control with WPF so that the control can be used multiple times in a view for different data. With DependencyProperty 'DiagramLevelItemsSource' can be bound with a list.


```
  <Diagram:BarDiagramControl HorizontalAlignment="Stretch" 
                             VerticalAlignment="Stretch" 
                             DiagramLevelItemsSource="{Binding Items}"/>
```

#
##### Deutsch

## Kleine Lösung
Diesmal komme ich hier mit etwas relativ einfachem. Hintergrund ist, dass ich mir selbst ein eigenen Rahmen zusammenstelle, mit dem ich meine Programm immer das selbe selbe Ausehen verpasse. Dazu kommt, dass auch einige Steuerelemente selbst erstellt werden und daher nicht von externen Anbieter verwendet werden. Soll ja schließlich für den Privaten gebrauch sein.

## Was zeigt die Lösung
Aufbau eines wiederverwendbares Steuerelement mit WPF, so dass das Steuerlement in einer Ansicht mehrmals für verschiedene Daten eingesetzt werden kann. Mit DependencyProperty 'DiagramLevelItemsSource' kann eine Listen gebindet werden.

```
  <Diagram:BarDiagramControl HorizontalAlignment="Stretch" 
                             VerticalAlignment="Stretch" 
                             DiagramLevelItemsSource="{Binding Items}"/>
```

