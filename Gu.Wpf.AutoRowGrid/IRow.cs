namespace Gu.Wpf.AutoRowGrid
{
    using System.Windows;

    /// <summary>Used only for constraining <see cref="Rows"/>.</summary>
    public interface IRow
    {
        /// <summary>
        /// Gets or sets the name.
        /// The Name is not used for anything but can perhaps be good for documenting the xaml.
        /// </summary>
        string? Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if children of this row should get column index from their position in the row.
        /// If set to inherit parents incrementation settings are used.
        /// Default is Inherit.
        /// </summary>
        AutoIncrementation AutoIncrementation { get; set; }

        /// <summary>
        /// Gets or sets a value for what height should be used when generating rows for the grid.
        /// Default is null meaning it inherits from parent.
        /// </summary>
        GridLength? Height { get; set; }

        /// <summary>
        /// Update all nested children column indices.
        /// This should probably just be called by <see cref="GridExtension"/> but leaving it public.
        /// </summary>
        /// <param name="parentAutoIncrementation">The incrementation mode of the parent.</param>
        /// <param name="parentRowHeight">The row height specified for the parent.</param>
        void Inherit(AutoIncrementation parentAutoIncrementation, GridLength parentRowHeight);
    }
}
