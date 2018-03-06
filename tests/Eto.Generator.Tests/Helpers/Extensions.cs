namespace Eto.Generator.Tests.Helpers
{
    public static class Extensions
    {
        public static T As<T>(this object self) where T : class => self as T;
    }
}