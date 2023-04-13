#pragma warning disable INPC001 // Implement INotifyPropertyChanged.
namespace Gu.Wpf.AutoRowGrid;

using System.Collections.ObjectModel;
using System.Windows;

/// <summary>
/// A collection of <see cref="Row"/> or <see cref="Rows"/>
/// This is only used to group things in xaml.
/// </summary>
public class Rows : Collection<IRow>, IRow
{
    /// <summary>Gets or sets a name that is not used for anything but can perhaps be good for documentation.</summary>
    public string? Name { get; set; }

    /// <inheritdoc/>
    public AutoIncrementation AutoIncrementation { get; set; } = AutoIncrementation.Inherit;

    /// <inheritdoc/>
    public GridLength? Height { get; set; }

    /// <inheritdoc/>
    public void Inherit(AutoIncrementation parentAutoIncrementation, GridLength parentRowHeight)
    {
        this.Height ??= parentRowHeight;
        var autoIncrementation = this.AutoIncrementation.CoerceWith(parentAutoIncrementation);
        foreach (var row in this)
        {
            row.Inherit(autoIncrementation, this.Height.Value);
        }
    }
}
