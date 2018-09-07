namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    public static class TextBoxView
    {
        public static readonly DependencyProperty MarginProperty = DependencyProperty.RegisterAttached(
            "Margin",
            typeof(Thickness?),
            typeof(TextBoxView),
            new PropertyMetadata(null, OnMarginChanged));

        public static Type Type { get; } = typeof(TextBox).Assembly.GetTypes().Single(x => x.Name == "TextBoxView");

        public static void SetMargin(TextBox element, Thickness? value)
        {
            element.SetValue(MarginProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static Thickness? GetMargin(TextBox element)
        {
            return (Thickness?)element.GetValue(MarginProperty);
        }

        private static void OnMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)d;
            OnMarginChanged(textBox, (Thickness?)e.NewValue);
        }

        private static void OnMarginChanged(TextBox textBox, Thickness? margin)
        {
            if (!textBox.IsLoaded)
            {
                _ = textBox.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => OnMarginChanged(textBox, margin)));
                return;
            }

            var textBoxView = textBox.NestedChildren()
                                     .SingleOrDefault(x => x.GetType().Name == "TextBoxView");
            if (margin == null)
            {
                textBoxView?.ClearValue(FrameworkElement.MarginProperty);
            }
            else
            {
                textBoxView?.SetCurrentValue(FrameworkElement.MarginProperty, margin.Value);
            }
        }
    }
}
