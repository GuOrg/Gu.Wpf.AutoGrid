using System.Globalization;

namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public static class WindowExt
    {
        public static string GetTextBoxPosition(this Window window, string textBoxName)
        {
            var groupBox = window.Get<GroupBox>();
            var textBox = groupBox.Get<TextBox>(textBoxName);
            var topLeft = textBox.Bounds.TopLeft - groupBox.Bounds.TopLeft;
            var bottomRight = textBox.Bounds.BottomRight - groupBox.Bounds.TopLeft;
            return $"{topLeft.ToString(CultureInfo.InvariantCulture)} {bottomRight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
