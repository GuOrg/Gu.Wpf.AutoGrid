using System.Globalization;

namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public static class WindowExt
    {
        public static string GetItemPosition(this Window window, string name)
        {
            var groupBox = window.Get<GroupBox>();
            var item = groupBox.Get<UIItem>(name);
            var topLeft = item.Bounds.TopLeft - groupBox.Bounds.TopLeft;
            var bottomRight = item.Bounds.BottomRight - groupBox.Bounds.TopLeft;
            return $"{topLeft.ToString(CultureInfo.InvariantCulture)} {bottomRight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
