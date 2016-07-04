namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Threading;

    public static class TextBoxView
    {
        public static readonly DependencyProperty MarginProperty = DependencyProperty.RegisterAttached(
            "Margin",
            typeof(Thickness),
            typeof(TextBoxView),
            new PropertyMetadata(default(Thickness), OnTextBoxViewMarginChanged));

        public static Type Type { get; } = typeof(TextBox).Assembly.GetTypes().Single(x => x.Name == "TextBoxView");

        public static void SetMargin(TextBox element, Thickness value)
        {
            element.SetValue(MarginProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static Thickness GetMargin(TextBox element)
        {
            return (Thickness)element.GetValue(MarginProperty);
        }

        private static void OnTextBoxViewMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)d;
            OnTextBoxViewMarginChanged(textBox, (Thickness)e.NewValue);
        }

        private static void OnTextBoxViewMarginChanged(TextBox textBox, Thickness margin)
        {
            if (!textBox.IsLoaded)
            {
                textBox.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => OnTextBoxViewMarginChanged(textBox, margin)));
                return;
            }

            var textBoxView = textBox.NestedChildren()
                                     .SingleOrDefault(x => x.GetType().Name == "TextBoxView");

            textBoxView?.SetValue(FrameworkElement.MarginProperty, margin);
        }

        private static IEnumerable<DependencyObject> NestedChildren(this DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                yield return child;
                if (VisualTreeHelper.GetChildrenCount(child) == 0)
                {
                    continue;
                }

                foreach (var nestedChild in NestedChildren(child))
                {
                    yield return nestedChild;
                }
            }
        }
    }
}
