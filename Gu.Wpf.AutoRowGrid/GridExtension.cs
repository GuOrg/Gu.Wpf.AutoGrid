namespace Gu.Wpf.AutoRowGrid
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Grid))]
    [ContentProperty("Rows")]
    public class GridExtension : MarkupExtension
    {
        public ColumnDefinitions.ColumnDefinitions ColumnDefinitions { get; set; } = new ColumnDefinitions.ColumnDefinitions();

        public ChildCollection Rows { get; set; } = new ChildCollection();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var grid = new Grid();
            AddRows(grid, this.Rows);

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

        private static void AddRows(Grid grid, IEnumerable<object> children)
        {
            foreach (var item in children)
            {
                var uiElement = item as UIElement;
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

                var rowItem = item as Row;
                if (rowItem != null)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var rowIndex = grid.RowDefinitions.Count - 1;
                    foreach (var child in rowItem)
                    {
                        grid.Children.Add(child);
                        Grid.SetRow(child, rowIndex);
                    }

                    continue;
                }

                AddRows(grid, (Rows)item);
            }
        }

        public class ChildCollection : Collection<object>
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
                if (item is Row || item is Rows || item is UIElement)
                {
                    return;
                }

                throw new ArgumentException($"Only items of type {typeof(UIElement).FullName} or {typeof(Row).FullName} or {typeof(Rows).FullName} are allowed.");
            }
        }
    }
}
