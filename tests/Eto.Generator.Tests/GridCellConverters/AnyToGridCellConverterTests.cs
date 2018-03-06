using Eto.Forms;
using Eto.Generator.GridCellConverters;
using Eto.Generator.Tests.Helpers;
using Moq;
using Shouldly;
using Xunit;


namespace Eto.Generator.Tests.GridCellConverters
{
    public class AnyToGridCellConverterTests : EtoTestBase
    {
        [Fact]
        public void Convert_WhenAnyPropertyTypePassed_TextBoxCellWithCorrentBinding()
        {
            //Given
            var toStringValue = "ToStringValue";

            var childModel = new Mock<ITestModel>();
            childModel.Setup(m => m.ToString()).Returns(toStringValue);

            var model = new Mock<ITestModel>();
            model.SetupGet(m => m.ChildModel).Returns(childModel.Object);
            var property = model.Object.GetType().GetProperty(nameof(ITestModel.ChildModel));

            //When
            var cell = new AnyToGridCellConverter().Convert(property);

            //Then
            cell.ShouldBeOfType<TextBoxCell>();
            cell.As<TextBoxCell>().Binding.GetValue(model.Object).ShouldBe(toStringValue);
        }
    }
}