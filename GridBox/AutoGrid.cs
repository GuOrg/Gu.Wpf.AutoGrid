namespace GridBox
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Grid))]
    public class AutoGrid : MarkupExtension, IList
    {
        private readonly List<UIElement> children = new List<UIElement>();

        public int Count => children.Count;

        public bool IsReadOnly => ((IList)children).IsReadOnly;

        public bool IsFixedSize => ((IList)children).IsReadOnly;

        public object SyncRoot => ((ICollection)children).SyncRoot;

        public bool IsSynchronized => ((ICollection)children).IsSynchronized;

        public object this[int index]
        {
            get { return ((IList)children)[index]; }
            set { ((IList)children)[index] = value; }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var grid = new Grid();
            for (int i = 0; i < children.Count; i++)
            {
                var child =(UIElement) children[i];
                Grid.SetRow(child, i);
                grid.Children.Add( child);
                grid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            return grid;
        }

        public IEnumerator GetEnumerator() => children.GetEnumerator();

        public void CopyTo(Array array, int index) => ((IList)children).CopyTo(array, index);

        public int Add(object value) => ((IList)children).Add(value);

        public bool Contains(object value) => ((IList)children).Contains(value);

        public void Clear() => children.Clear();

        public int IndexOf(object value) => ((IList)children).IndexOf(value);

        public void Insert(int index, object value) => ((IList)children).Insert(index, value);

        public void Remove(object value) => ((IList)children).Remove(value);

        public void RemoveAt(int index) => ((IList)children).RemoveAt(index);
    }
}
