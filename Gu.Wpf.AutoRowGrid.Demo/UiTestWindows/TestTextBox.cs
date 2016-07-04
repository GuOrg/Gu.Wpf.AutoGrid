namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    public static class TestTextBox
    {
        public static readonly DependencyProperty AllNestedMarginsAndPaddingsProperty = DependencyProperty.RegisterAttached(
            "AllNestedMarginsAndPaddings",
            typeof(Thickness?),
            typeof(TestTextBox),
            new PropertyMetadata(
                default(Thickness?),
                OnAllNestedMarginsAndPaddingsChanged));

        public static void SetAllNestedMarginsAndPaddings(this TextBox element, Thickness? value)
        {
            element.SetValue(AllNestedMarginsAndPaddingsProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static Thickness? GetAllNestedMarginsAndPaddings(this TextBox element)
        {
            return (Thickness?)element.GetValue(AllNestedMarginsAndPaddingsProperty);
        }


        private static void OnAllNestedMarginsAndPaddingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)d;
            OnTextBoxViewMarginChanged(textBox, (Thickness?)e.NewValue);
        }

        private static void OnTextBoxViewMarginChanged(TextBox textBox, Thickness? margin)
        {
            if (!textBox.IsLoaded)
            {
                textBox.Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    new Action(() => OnTextBoxViewMarginChanged(textBox, margin)));
                return;
            }

            foreach (var child in textBox.NestedChildren().OfType<FrameworkElement>())
            {
                if (margin == null)
                {
                    child.ClearValue(FrameworkElement.MarginProperty);
                }
                else
                {
                    child.SetValue(FrameworkElement.MarginProperty, margin.Value);
                }
            }
        }
    }
}