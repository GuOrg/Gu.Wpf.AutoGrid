namespace Gu.Wpf.AutoRowGrid;

/// <summary>What auto incrementation strategy to use.</summary>
public enum AutoIncrementation
{
    /// <summary>Inherit setting from parent.</summary>
    Inherit,

    /// <summary><see cref="System.Windows.UIElement"/> children of a <see cref="Row"/> get column index from position in the collection.</summary>
    AutoIncrement,

    /// <summary>Grid.Column="n" is specified manually in XAML.</summary>
    UseExplicitColumns,
}
