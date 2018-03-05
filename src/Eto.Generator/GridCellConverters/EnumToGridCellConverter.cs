using System.Reflection;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public class EnumToGridCellConverter : IGridCellConverter
    {
        public Cell Convert(PropertyInfo property)
        {
            if (!property.PropertyType.IsEnum) return null;
            return new ComboBoxCell(property.Name);
            //TODO: Add items
        }
    }
}