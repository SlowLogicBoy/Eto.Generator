using System.Collections;
using System.Reflection;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public class EnumerableToGridCellConverter : IGridCellConverter
    {
        public int Count(IEnumerable source)
        {
            if (source == null) return 0;
            var col = source as ICollection;
            if (col != null)
                return col.Count;

            int count = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                count++;
            return count;
        }
        public Cell Convert(PropertyInfo property)
        {
            if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) return null;
            return new TextBoxCell
            {
                Binding = Binding.Delegate((object o) => Count((property.GetValue(o) as IEnumerable)).ToString())
            };
        }
    }
}