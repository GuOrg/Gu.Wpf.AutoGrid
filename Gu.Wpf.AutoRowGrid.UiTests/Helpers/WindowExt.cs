namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using System.Globalization;
    using Gu.Wpf.UiAutomation;

    public static class WindowExt
    {
        public static string GetItemPosition(this Window window, string name)
        {
            var groupBox = window.FindGroupBox();
            var item = groupBox.FindFirstDescendant(Conditions.ByAutomationId(name));
            var topLeft = item.Bounds.TopLeft - groupBox.Bounds.TopLeft;
            var bottomRight = item.Bounds.BottomRight - groupBox.Bounds.TopLeft;
            return $"{topLeft.ToString(CultureInfo.InvariantCulture)} {bottomRight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
