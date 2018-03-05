using System;
using System.Collections.Generic;
using System.Linq;
using Eto.Forms;
using Eto.Generator.GridCellConverters;

namespace Eto.Generator
{
    public class GridViewGenerator : IGridViewGenerator
    {
        readonly IEnumerable<IGridCellConverter> _converters;
        public static IGridCellConverter[] GetDefaultGridCellConverters() => new IGridCellConverter[] {
            new BoolToGridCellConverter(),
            new StringToGridCellConverter(),
            new ImageToGridCellConverter(),
            new EnumToGridCellConverter(),
            new EnumerableToGridCellConverter(),
            new AnyToGridCellConverter()
        };
        public GridViewGenerator()
        {
            _converters = GetDefaultGridCellConverters();
        }

        public GridViewGenerator(IEnumerable<IGridCellConverter> gridCellConverters)
        {
            _converters = gridCellConverters;
        }

        void AddColumns(GridView grid, Type type, GridViewGeneratorSettings settings)
        {
            if (settings == null)
                settings = new GridViewGeneratorSettings();
            var properties = type.GetProperties().Where(p => p.CanRead);
            foreach (var property in properties)
            {
                var cell = _converters.Select(c => c.Convert(property)).FirstOrDefault(c => c != null);
                if (cell == null) continue;

                grid.Columns.Add(new GridColumn
                {
                    HeaderText = settings.HeaderTextDelegate?.Invoke(property),
                    DataCell = cell
                });
            }
        }

        public GridView<T> GetGridView<T>(GridViewGeneratorSettings settings = null) where T : class
        {
            var grid = new GridView<T>();
            AddColumns(grid, typeof(T), settings);
            return grid;
        }

        public GridView GetGridView(Type type, GridViewGeneratorSettings settings = null)
        {
            var grid = new GridView();
            AddColumns(grid, type, settings);
            return grid;
        }
    }
}