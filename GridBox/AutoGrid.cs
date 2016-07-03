namespace GridBox
{
    using System.Collections;
    using System.Windows;
    using System.Windows.Controls;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Grid))]
    [ContentProperty("Rows")]
    public class AutoGrid : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var grid = this.Rows?.Grid;
            if (grid == null)
            {
                return null;
            }

            var rows = grid.Children.OfType<UIElement>().Max(Grid.GetRow);
            while (rows > grid.RowDefinitions.Count - 1)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            if (this.ColumnDefinitions != null)
            {
                foreach (var columnDefinition in this.ColumnDefinitions)
                {
                    grid.ColumnDefinitions.Add(columnDefinition);
                }
            }

            return grid;
        }

        public ColumnDefinitions ColumnDefinitions { get; set; }

        public AutoGridRows Rows { get; set; } = new AutoGridRows();

        public class AutoGridRows : IList
        {
            internal readonly Grid Grid = new Grid();

            public int Count => ThrowNotSupported<int>();

            public bool IsReadOnly => false;

            public bool IsFixedSize => false;

            public object SyncRoot => ThrowNotSupported<object>();

            public bool IsSynchronized => ThrowNotSupported<bool>();

            public object this[int index]
            {
                get { return ThrowNotSupported<object>(); }
                set { ThrowNotSupported(); }
            }

            public IEnumerator GetEnumerator() => ThrowNotSupported<IEnumerator>();

            public void CopyTo(Array array, int index) => ThrowNotSupported();

            public int Add(object value)
            {
                var uiElement = (UIElement)value;
                this.Grid.Children.Add(uiElement);
                return 0;
            }

            public bool Contains(object value) => ThrowNotSupported<bool>();

            public void Clear()
            {
                this.Grid.Children.Clear();
                this.Grid.RowDefinitions.Clear();
            }

            public int IndexOf(object value) => ThrowNotSupported<int>();

            public void Insert(int index, object value) => ThrowNotSupported();

            public void Remove(object value) => ThrowNotSupported();

            public void RemoveAt(int index) => ThrowNotSupported();

            private static void ThrowNotSupported([CallerMemberName] string caller = null)
            {
                throw new NotSupportedException($"{typeof(AutoGridRows).Name} does not support {caller}");
            }

            private static T ThrowNotSupported<T>([CallerMemberName] string caller = null)
            {
                throw new NotSupportedException($"{typeof(AutoGridRows).Name} does not support {caller}");
            }
        }
    }
}
