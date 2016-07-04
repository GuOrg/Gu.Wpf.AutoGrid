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

        public static void SetAllNestedMarginsAndPaddings(this FrameworkElement element, Thickness? value)
        {
            element.SetValue(AllNestedMarginsAndPaddingsProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static Thickness? GetAllNestedMarginsAndPaddings(this FrameworkElement element)
        {
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
                textBox.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => OnTextBoxViewMarginChanged(textBox, thickness)));
                return;
            }

            foreach (var child in textBox.NestedChildren().OfType<FrameworkElement>())
            {
                if (thickness == null)
                {
                    child.ClearValue(FrameworkElement.MarginProperty);
                }
                else
                {
                    child.SetValue(FrameworkElement.MarginProperty, thickness.Value);
                }
            }

            foreach (var child in textBox.NestedChildren().OfType<Control>())
            {
                if (thickness == null)
                {
                    child.ClearValue(Control.PaddingProperty);
                }
                else
                {
                    child.SetValue(Control.PaddingProperty, thickness.Value);
                }
            }
        }
    }
}