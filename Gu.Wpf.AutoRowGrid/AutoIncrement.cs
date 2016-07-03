namespace Gu.Wpf.AutoRowGrid
{
    using System.Windows;

    /// <summary>Provides an attached proerpty fro setting autoincrementation for an <see cref="UIElement"/> </summary>
    public static class AutoIncrement
    {
        /// <summary>An attached property for setting <see cref="AutoIncrementation"/> on a single element.</summary>
        public static readonly DependencyProperty AutoIncrementationProperty = DependencyProperty.RegisterAttached(
            "AutoIncrementation",
            typeof(AutoIncrementation),
            typeof(AutoIncrement),
            new FrameworkPropertyMetadata(AutoIncrementation.Inherit, FrameworkPropertyMetadataOptions.NotDataBindable));

        /// <summary>An attached property for setting <see cref="AutoIncrementation"/> on a single element.</summary>
        public static void SetAutoIncrementation(this UIElement element, AutoIncrementation value)
        {
            element.SetValue(AutoIncrementationProperty, value);
        }

        /// <summary>An attached property for setting <see cref="AutoIncrementation"/> on a single element.</summary>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static AutoIncrementation GetAutoIncrementation(this UIElement element)
        {
            return (AutoIncrementation)element.GetValue(AutoIncrementationProperty);
        }

        internal static AutoIncrementation CoerceWith(this AutoIncrementation self, AutoIncrementation parent)
        {
            if (self == AutoIncrementation.Inherit)
            {
                return parent;
            }

            return self;
        }
    }
}