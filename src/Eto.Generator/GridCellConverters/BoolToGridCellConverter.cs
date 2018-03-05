using System.Reflection;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public class BoolToGridCellConverter : IGridCellConverter
    {
        public Cell Convert(PropertyInfo property)
        {
            if (!typeof(bool?).IsAssignableFrom(property.PropertyType)) return null;
            return new CheckBoxCell(property.Name);
        }
    }
}