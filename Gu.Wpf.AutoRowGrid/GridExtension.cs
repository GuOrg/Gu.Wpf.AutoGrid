namespace Gu.Wpf.AutoRowGrid
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    /// <summary>Helper for creating <see cref="Grid"/></summary>
    [MarkupExtensionReturnType(typeof(Grid))]
    [ContentProperty("Rows")]
    [DefaultProperty("Rows")]
    public class GridExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets a value that specifies if content of rows will get column index from index.
        /// Default is Increment.
        /// This will be used for all subnodes that have Inherit.
        /// </summary>
        public static AutoIncrementation GlobalAutoIncrementation { get; set; } = AutoIncrementation.AutoIncrement;

        /// <summary> Gets or sets see <see cref="Grid.ColumnDefinitions"/> </summary>
        public ColumnDefinitions ColumnDefinitions { get; set; } = new ColumnDefinitions();

        /// <summary>
        /// Gets or sets a value for what height should be used when generating rows for the grid.
        /// Default is Auto.
        /// </summary>
        public GridLength RowHeight { get; set; } = GridLength.Auto;

        /// <summary>
        /// Gets or sets a value thatspecifies if content of rows will get column index from index.
        /// Default is Increment.
        /// </summary>
        public AutoIncrementation AutoIncrementation { get; set; } = GlobalAutoIncrementation;

        /// <summary>
        /// Gets or sets a value indicating how the last row is handled.
        /// If true tha last row gets Height = "*".
        /// If false an extra row with  Height = "*" is added to fill remaining space.</summary>
        public bool LastRowFill { get; set; } = false;

        /// <summary> Gets or sets the children that are used when creating the grid.</summary>
        public ChildCollection Rows { get; set; } = new ChildCollection();

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var grid = new Grid();
            this.Rows.Inherit(this.AutoIncrementation, this.RowHeight);
            AddRowsRecursive(grid, this.Rows, this.RowHeight);
            if (grid.RowDefinitions.All(x => !x.Height.IsStar))
            {
                if (this.LastRowFill)
                {
                    grid.RowDefinitions[grid.RowDefinitions.Count - 1].SetCurrentValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Star));
                }
                else
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                }
            }

            if (this.ColumnDefinitions != null)
            {
                foreach (var columnDefinition in this.ColumnDefinitions)
                {
                    grid.ColumnDefinitions.Add(columnDefinition);
                }
            }

            return grid;
        }

        private static void AddRowsRecursive(Grid grid, IEnumerable<object> children, GridLength rowHeight)
        {
            foreach (var item in children)
            {
                var uiElement = item as UIElement;
                if (uiElement != null)
                {
                    grid.Children.Add(uiElement);
                    var maxRow = Grid.GetRow(uiElement);
                    while (maxRow > grid.RowDefinitions.Count - 1)
                    {
                        grid.RowDefinitions.Add(new RowDefinition { Height = rowHeight });
                    }

                    continue;
                }

                var rowItem = item as Row;
                if (rowItem != null)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = rowItem.Height ?? rowHeight });
                    var rowIndex = grid.RowDefinitions.Count - 1;
                    foreach (var child in rowItem)
                    {
                        grid.Children.Add(child);
                        Grid.SetRow(child, rowIndex);
                    }

                    continue;
                }

                // this can't SO since WPF already checks that an element can only have one parent.
                // letting it fail with the framework exception.
                var rows = (Rows)item;
                AddRowsRecursive(grid, rows, rows.Height ?? GridLength.Auto);
            }
        }

        /// <summary>A collection of children for <see cref="GridExtension"/> </summary>
        public class ChildCollection : Collection<object>
        {
            /// <summary>Update all nested children recursively with the settings from parent.</summary>
            internal void Inherit(AutoIncrementation autoIncrementation, GridLength parentRowHeight)
            {
                foreach (var row in this.Items.OfType<IRow>())
                {
                    row.Inherit(autoIncrementation, parentRowHeight);
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
