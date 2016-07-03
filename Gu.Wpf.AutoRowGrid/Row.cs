namespace Gu.Wpf.AutoRowGrid
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    public class Row : Collection<UIElement>, IRow
    {
        /// <summary><see cref="Name"/> is not used for anything but can perhaps be good for documentation.</summary>
        public string Name { get; set; }

        public AutoIncrementation AutoIncrementation { get; set; } = AutoIncrementation.Inherit;

        public void AutoIncrement(AutoIncrementation parentAutoIncrementation)
        {
            var autoIncrementation = this.AutoIncrementation.CoerceWith(parentAutoIncrementation);
            if (autoIncrementation == AutoIncrementation.AutoIncrement)
            {
                var columnIndex = 0;
                for (int i = 0; i < this.Items.Count; i++)
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
}