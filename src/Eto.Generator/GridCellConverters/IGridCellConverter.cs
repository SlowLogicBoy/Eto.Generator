using System.Reflection;
using Eto.Forms;

namespace Eto.Generator.GridCellConverters
{
    public interface IGridCellConverter
    {
        /// <summary>
        /// converts property to grid data cell
        /// </summary>
        /// <param name="property"></param>
        /// <returns>non null if success, null if can't convert</returns>
        Cell Convert(PropertyInfo property);
    }
}