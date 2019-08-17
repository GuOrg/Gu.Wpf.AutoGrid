namespace Gu.Wpf.AutoRowGrid
{
    using System.Windows;

    /// <summary>Provides an attached proerpty fro setting autoincrementation for an <see cref="UIElement"/>. </summary>
    public static class AutoIncrement
    {
        /// <summary>An attached property for setting <see cref="AutoIncrementation"/> on a single element.</summary>
        public static readonly DependencyProperty AutoIncrementationProperty = DependencyProperty.RegisterAttached(
            "AutoIncrementation",
            typeof(AutoIncrementation),
            typeof(AutoIncrement),
            new FrameworkPropertyMetadata(AutoIncrementation.Inherit, FrameworkPropertyMetadataOptions.NotDataBindable));

        /// <summary>Helper for setting <see cref="AutoIncrementationProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to set <see cref="AutoIncrementationProperty"/> on.</param>
        /// <param name="value">AutoIncrementation property value.</param>
        public static void SetAutoIncrementation(this UIElement element, AutoIncrementation value)
        {
            element.SetValue(AutoIncrementationProperty, value);
        }

        /// <summary>Helper for getting <see cref="AutoIncrementationProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to read <see cref="AutoIncrementationProperty"/> from.</param>
        /// <returns>AutoIncrementation property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static AutoIncrementation GetAutoIncrementation(this UIElement element)
        {
            return (AutoIncrementation)element.GetValue(AutoIncrementationProperty);
        }

        /// <summary>If self is Inherit use <paramref name="parentValue"/>.</summary>
        internal static AutoIncrementation CoerceWith(this AutoIncrementation self, AutoIncrementation parentValue)
        {
            if (self == AutoIncrementation.Inherit)
            {
                return parentValue;
            }

            return self;
        }
    }
}
