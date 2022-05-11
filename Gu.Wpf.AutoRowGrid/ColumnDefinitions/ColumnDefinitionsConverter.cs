namespace Gu.Wpf.AutoRowGrid
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;

    /// <inheritdoc/>
    public class ColumnDefinitionsConverter : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        /// <inheritdoc/>
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return false;
        }

        /// <inheritdoc/>
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string text)
            {
                var lengths = GridLengthsParser.Parse(context, culture, text);
                var columnDefinitions = lengths.Select(gl => new System.Windows.Controls.ColumnDefinition { Width = gl })
                                               .ToArray();
                return new ColumnDefinitions(columnDefinitions);
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            throw new NotSupportedException();
        }
    }
}
