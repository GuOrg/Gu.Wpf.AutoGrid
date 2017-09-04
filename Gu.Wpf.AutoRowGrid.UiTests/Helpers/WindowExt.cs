namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using System.Globalization;
    using Gu.Wpf.UiAutomation;

    public static class WindowExt
    {
        public static string GetItemPosition(this Window window, string name)
        {
            var groupBox = window.FindGroupBox();
            var item = groupBox.FindFirstDescendant(x => x.ByAutomationId(name));
            var topLeft = item.BoundingRectangle.TopLeft - groupBox.BoundingRectangle.TopLeft;
            var bottomRight = item.BoundingRectangle.BottomRight - groupBox.BoundingRectangle.TopLeft;
            return $"{topLeft.ToString(CultureInfo.InvariantCulture)} {bottomRight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
