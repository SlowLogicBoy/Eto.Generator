using System;
using Eto.Forms;

namespace Eto.Generator
{
    public interface IGridViewGenerator
    {
        GridView<T> GetGridView<T>(GridViewGeneratorSettings settings = null) where T : class;
        GridView GetGridView(Type type, GridViewGeneratorSettings settings = null);
    }
}