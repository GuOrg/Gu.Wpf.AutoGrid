namespace Gu.Wpf.AutoRowGrid
{
    using System.Collections.ObjectModel;

    public class Rows : Collection<IRow>, IRow
    {
        /// <summary><see cref="Name"/> is not used for anything but can perhaps be good for documentation.</summary>
        public string Name { get; set; }

        public AutoIncrementation AutoIncrementation { get; set; } = AutoIncrementation.Inherit;

        public void AutoIncrement(AutoIncrementation parentAutoIncrementation)
        {
            var autoIncrementation = this.AutoIncrementation.CoerceWith(parentAutoIncrementation);
            foreach (var row in this)
            {
                row.AutoIncrement(autoIncrementation);
            }
        }
    }
}