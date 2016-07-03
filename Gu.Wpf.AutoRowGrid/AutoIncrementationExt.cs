namespace Gu.Wpf.AutoRowGrid
{
    internal static class AutoIncrementationExt
    {
        public static AutoIncrementation CoerceWith(this AutoIncrementation self, AutoIncrementation parent)
        {
            if (self == AutoIncrementation.Inherit)
            {
                return parent;
            }

            return self;
        }
    }
}