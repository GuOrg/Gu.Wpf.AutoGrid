namespace Gu.Wpf.AutoRowGrid
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    /// <summary>
    /// <see cref="System.Windows.Controls.ColumnDefinitionCollection"/> is sealed with internal ctor. Hence this class.
    /// Only used as a returnvalue from <see cref="ColumnDefinitionsConverter"/>
    /// </summary>
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