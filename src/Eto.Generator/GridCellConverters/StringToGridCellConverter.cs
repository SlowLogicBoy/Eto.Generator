using System.Reflection;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public class StringToGridCellConverter : IGridCellConverter
    {
        public Cell Convert(PropertyInfo property)
        {
            if (!typeof(string).IsAssignableFrom(property.PropertyType))
                return null;
            return new TextBoxCell(property.Name);
        }
    }
}