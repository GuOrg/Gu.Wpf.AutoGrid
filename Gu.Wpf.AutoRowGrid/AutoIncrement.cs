namespace Gu.Wpf.AutoRowGrid
{
    using System.Windows;

    public static class AutoIncrement
    {
        public static readonly DependencyProperty AutoIncrementationProperty = DependencyProperty.RegisterAttached(
            "AutoIncrementation",
            typeof(AutoIncrementation),
            typeof(AutoIncrement),
            new FrameworkPropertyMetadata(AutoIncrementation.Inherit, FrameworkPropertyMetadataOptions.NotDataBindable));

        public static void SetAutoIncrementation(this UIElement element, AutoIncrementation value)
        {
            element.SetValue(AutoIncrementationProperty, value);
        }

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