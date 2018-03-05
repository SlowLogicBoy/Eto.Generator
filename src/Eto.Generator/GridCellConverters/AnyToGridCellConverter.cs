using System.Reflection;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public class AnyToGridCellConverter : IGridCellConverter
    {
        public Cell Convert(PropertyInfo property)
        {
            return new TextBoxCell
            {
                Binding = Binding.Delegate((object o) => property.GetValue(o)?.ToString() ?? "Null")
            };
        }
    }
}