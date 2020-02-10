namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    public static class TestElement
    {
        public static readonly DependencyProperty AllNestedMarginsAndPaddingsProperty = DependencyProperty.RegisterAttached(
            "AllNestedMarginsAndPaddings",
            typeof(Thickness?),
            typeof(TestElement),
            new PropertyMetadata(
                default(Thickness?),
                OnAllNestedMarginsAndPaddingsChanged));

        /// <summary>Helper for setting <see cref="AllNestedMarginsAndPaddingsProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="FrameworkElement"/> to set <see cref="AllNestedMarginsAndPaddingsProperty"/> on.</param>
        /// <param name="value">AllNestedMarginsAndPaddings property value.</param>
        public static void SetAllNestedMarginsAndPaddings(this FrameworkElement element, Thickness? value)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(AllNestedMarginsAndPaddingsProperty, value);
        }

        /// <summary>Helper for getting <see cref="AllNestedMarginsAndPaddingsProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="FrameworkElement"/> to read <see cref="AllNestedMarginsAndPaddingsProperty"/> from.</param>
        /// <returns>AllNestedMarginsAndPaddings property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static Thickness? GetAllNestedMarginsAndPaddings(this FrameworkElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return (Thickness?)element.GetValue(AllNestedMarginsAndPaddingsProperty);
        }

        private static void OnAllNestedMarginsAndPaddingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (FrameworkElement)d;
            OnTextBoxViewMarginChanged(textBox, (Thickness?)e.NewValue);
        }

        private static void OnTextBoxViewMarginChanged(FrameworkElement textBox, Thickness? thickness)
        {
            if (!textBox.IsLoaded)
            {
                _ = textBox.Dispatcher.BeginInvoke(
                     DispatcherPriority.Loaded,
                     new Action(() => OnTextBoxViewMarginChanged(textBox, thickness)));
                return;
            }

            foreach (var child in textBox.NestedChildren().OfType<FrameworkElement>())
            {
                if (thickness is null)
                {
                    child.ClearValue(FrameworkElement.MarginProperty);
                }
                else
                {
                    child.SetCurrentValue(FrameworkElement.MarginProperty, thickness.Value);
                }
            }

            foreach (var child in textBox.NestedChildren().OfType<Control>())
            {
                if (thickness is null)
                {
                    child.ClearValue(Control.PaddingProperty);
                }
                else
                {
                    child.SetCurrentValue(Control.PaddingProperty, thickness.Value);
                }
            }
        }
    }
}
