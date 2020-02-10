#pragma warning disable INPC001 // Implement INotifyPropertyChanged.
namespace Gu.Wpf.AutoRowGrid
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

                               /// <summary>
                               /// A collection of <see cref="UIElement"/> that will get the same Grid.Row="n"
                               /// Gets index from previous element added to the grid.
                               /// </summary>
    public class Row : Collection<UIElement>, IRow
    {
        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public AutoIncrementation AutoIncrementation { get; set; } = AutoIncrementation.Inherit;

        /// <inheritdoc/>
        public GridLength? Height { get; set; }

        /// <inheritdoc/>
        public void Inherit(AutoIncrementation parentAutoIncrementation, GridLength parentRowHeight)
        {
            this.Height ??= parentRowHeight;
            var autoIncrementation = this.AutoIncrementation.CoerceWith(parentAutoIncrementation);
            var columnIndex = 0;
            for (var i = 0; i < this.Items.Count; i++)
            {
                var uiElement = this.Items[i];
                var elementIncrementation = uiElement.GetAutoIncrementation()
                                                     .CoerceWith(autoIncrementation);
                if (elementIncrementation == AutoIncrementation.AutoIncrement)
                {
                    Grid.SetColumn(uiElement, columnIndex);
                    columnIndex++;
                }
            }
        }
    }
}
