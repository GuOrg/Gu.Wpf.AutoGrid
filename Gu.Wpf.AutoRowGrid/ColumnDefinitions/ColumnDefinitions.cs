namespace Gu.Wpf.AutoRowGrid
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    [TypeConverter(typeof(ColumnDefinitionsConverter))]
    public class ColumnDefinitions : Collection<System.Windows.Controls.ColumnDefinition>
    {
        public ColumnDefinitions()
        {
        }

        public ColumnDefinitions(IList<System.Windows.Controls.ColumnDefinition> collection)
            : base(collection)
        {
        }
    }
}