namespace Gu.Wpf.AutoRowGrid
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    /// <summary>Helper for creating <see cref="Grid"/></summary>
    [MarkupExtensionReturnType(typeof(Grid))]
    [ContentProperty("Rows")]
    public class GridExtension : MarkupExtension
    {
        /// <summary>
        /// Specifies if content of rows will get column index from index.
        /// Default is Increment.
        /// This will be used for all subnodes that have Inherit.
        /// </summary>
        public static AutoIncrementation GlobalAutoIncrementation { get; set; } = AutoIncrementation.AutoIncrement;

        /// <summary> See <see cref="Grid.ColumnDefinitions"/> </summary>
        public ColumnDefinitions ColumnDefinitions { get; set; } = new ColumnDefinitions();

        /// <summary>Specifies if content of rows will get column index from index. Default is Increment.</summary>
        public AutoIncrementation AutoIncrementation { get; set; } = GlobalAutoIncrementation;

        /// <summary> The contents that are used to generating the grid. </summary>
        public ChildCollection Rows { get; set; } = new ChildCollection();

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var grid = new Grid();
            this.Rows.AutoIncrement(this.AutoIncrementation);
            AddRowsRecursive(grid, this.Rows);

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

        private static void AddRowsRecursive(Grid grid, IEnumerable<object> children)
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

                // this can potentially SO but can't be written to do it from xaml.
                // not gonna protect against it
                AddRowsRecursive(grid, (Rows)item);
            }
        }

        /// <summary>A collection of children for <see cref="GridExtension"/> </summary>
        public class ChildCollection : Collection<object>
        {
            internal void AutoIncrement(AutoIncrementation autoIncrementation)
            {
                foreach (var row in this.Items.OfType<IRow>())
                {
                    row.AutoIncrement(autoIncrementation);
                }
            }

            /// <inheritdoc/>
            protected override void InsertItem(int index, object item)
            {
                BeforeAddItem(item);
                base.InsertItem(index, item);
            }

            /// <inheritdoc/>
            protected override void SetItem(int index, object item)
            {
                BeforeAddItem(item);
                base.SetItem(index, item);
            }

            private static void BeforeAddItem(object item)
            {
                if (item is UIElement || item is IRow)
                {
                    return;
                }

                throw new ArgumentException($"Only items of type {typeof(UIElement).FullName} or {typeof(Row).FullName} or {typeof(Rows).FullName} are allowed.");
            }
        }
    }
}
