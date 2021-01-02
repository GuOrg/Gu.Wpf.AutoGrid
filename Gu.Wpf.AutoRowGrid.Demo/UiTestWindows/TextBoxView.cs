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
            new PropertyMetadata(
                null,
                (d, e) => OnMarginChanged((TextBox)d, (Thickness?)e.NewValue)));

        public static Type Type { get; } = typeof(TextBox).Assembly.GetTypes().Single(x => x.Name == "TextBoxView");

        /// <summary>Helper for setting <see cref="MarginProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="TextBox"/> to set <see cref="MarginProperty"/> on.</param>
        /// <param name="value">Margin property value.</param>
        public static void SetMargin(TextBox element, Thickness? value)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(MarginProperty, value);
        }

        /// <summary>Helper for getting <see cref="MarginProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="TextBox"/> to read <see cref="MarginProperty"/> from.</param>
        /// <returns>Margin property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static Thickness? GetMargin(TextBox element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return (Thickness?)element.GetValue(MarginProperty);
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
            if (margin is null)
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
