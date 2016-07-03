namespace Gu.Wpf.AutoRowGrid
{
    public interface IRow
    {
        string Name { get; set; }

        AutoIncrementation AutoIncrementation { get; set; }

        void AutoIncrement(AutoIncrementation parentAutoIncrementation);
    }
}