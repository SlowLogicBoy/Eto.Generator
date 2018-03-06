namespace Eto.Generator.Tests.Helpers
{
    public interface ITestModel
    {
        ITestModel ChildModel { get; }
        bool? NullableBool { get; }
        bool Bool { get; }
    }
}