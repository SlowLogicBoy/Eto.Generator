using Eto.Forms;
using Eto.Generator.GridCellConverters;
using Eto.Generator.Tests.Helpers;
using Shouldly;
using Xunit;


namespace Eto.Generator.Tests.GridCellConverters
{
    public class AnyToGridCellConverterTest : EtoTestBase
    {
        public class TestParentModel
        {
            public TestModel Model { get; set; }
        }

        [Fact]
        public void Convert_WhenAnyPropertyTypePassed_TextBoxCellWithBinding()
        {
            var property = typeof(TestParentModel).GetProperty(nameof(TestParentModel.Model));
            var cell = new AnyToGridCellConverter().Convert(property);
            var model = new TestParentModel {
                Model = new TestModel()
            };
            cell.ShouldBeOfType<TextBoxCell>();
            ((TextBoxCell)cell).Binding.GetValue(model).ShouldBe(new TestModel().ToString());
        }
    }
}