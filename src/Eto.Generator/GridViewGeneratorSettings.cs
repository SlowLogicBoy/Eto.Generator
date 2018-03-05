using System;
using System.Reflection;

namespace Eto.Generator
{
    public class GridViewGeneratorSettings
    {
        public Func<PropertyInfo, string> HeaderTextDelegate { get; set; } = (info) => info.Name;
    }

    public static class GridViewGeneratorSettingsExtensions
    {
        public static GridViewGeneratorSettings SetHeaderTextDelegate(this GridViewGeneratorSettings @this, Func<PropertyInfo, string> headerTextDelegate)
        {
            @this.HeaderTextDelegate = headerTextDelegate;
            return @this;
        }
    }
}