using System.Reflection;
using Eto.Drawing;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public class ImageToGridCellConverter : IGridCellConverter
    {
        public Cell Convert(PropertyInfo property)
        {
            if (!typeof(Image).IsAssignableFrom(property.PropertyType))
                return null;
            return new ImageViewCell(property.Name);
        }
    }
}