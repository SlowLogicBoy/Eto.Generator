using Eto.Forms;
using Eto.Generator.GridCellConverters;
using Eto.Generator.Tests.Helpers;
using Moq;
using Shouldly;
using Xunit;


namespace Eto.Generator.Tests.GridCellConverters
{
    public class AnyToGridCellConverterTest : EtoTestBase
    {
        [Fact]
        public void Convert_WhenAnyPropertyTypePassed_TextBoxCellWithBinding()
        {
            //Arrange
            var toStringValue = "ToStringValue";

            var childModel = new Mock<ITestModel>();
            childModel.Setup(m => m.ToString()).Returns(toStringValue);

            var model = new Mock<ITestModel>();
            model.SetupGet(m => m.ChildModel).Returns(childModel.Object);
            var property = model.Object.GetType().GetProperty(nameof(ITestModel.ChildModel));

            //Act
            var cell = new AnyToGridCellConverter().Convert(property);

            //Assert
            cell.ShouldBeOfType<TextBoxCell>();
            cell.As<TextBoxCell>().Binding.GetValue(model.Object).ShouldBe(toStringValue);
        }
    }
}