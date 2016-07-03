namespace Gu.Wpf.AutoRowGrid
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Grid))]
    [ContentProperty("Rows")]
    public class GridExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var grid = new Grid();
            foreach (var row in this.Rows)
            {
                var uiElement = row as UIElement;
                if (uiElement != null)
                {
                    grid.Children.Add(uiElement);
                    var rows = Grid.GetRow(uiElement);
                    while (rows > grid.RowDefinitions.Count - 1)
                    {
                        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    }

                    continue;
                }

                var agr = (Row)row;
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var rowIndex = grid.RowDefinitions.Count - 1;
                foreach (var child in agr)
                {
                    grid.Children.Add(child);
                    Grid.SetRow(child, rowIndex);
                }
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            if (this.ColumnDefinitions != null)
            {
                foreach (var columnDefinition in this.ColumnDefinitions)
                {
                    grid.ColumnDefinitions.Add(columnDefinition);
                }
            }

            return grid;
        }

        public ColumnDefinitions.ColumnDefinitions ColumnDefinitions { get; set; }

        public AutoGridRows Rows { get; set; } = new AutoGridRows();

        public class AutoGridRows : Collection<object>
        {
            protected override void InsertItem(int index, object item)
            {
                AssertItem(item);
                base.InsertItem(index, item);
            }

            protected override void SetItem(int index, object item)
            {
                AssertItem(item);
                base.SetItem(index, item);
            }

            private static void AssertItem(object item)
            {
                if (item is Row || item is UIElement)
                {
                    return;
                }

                throw new ArgumentException($"Only items of type {typeof(UIElement).FullName} or {typeof(Row).Name} are allowed.");
            }
        }
    }
}
