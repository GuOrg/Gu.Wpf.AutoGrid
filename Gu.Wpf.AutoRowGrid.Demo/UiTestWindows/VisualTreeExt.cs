namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;

    internal static class VisualTreeExt
    {
        internal static IEnumerable<DependencyObject> NestedChildren(this DependencyObject parent)
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