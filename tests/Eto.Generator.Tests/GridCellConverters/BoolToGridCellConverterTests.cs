using System;
using System.Reflection;
using Eto.Forms;
using Eto.Generator.GridCellConverters;
using Eto.Generator.Tests.Helpers;
using Moq;
using Shouldly;
using Xunit;

namespace Eto.Generator.Tests.GridCellConverters
{
    public class BoolToGridCellConverterTests : EtoTestBase
    {
        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(ITestModel))]
        [InlineData(typeof(int))]
        [InlineData(typeof(double))]
        public void Convert_WhenPassedTypeIsNotBool_ReturnsNull(Type passedType)
        {
            //Given
            var propertyInfoMock = new Mock<PropertyInfo>();
            propertyInfoMock.SetupGet(p => p.PropertyType).Returns(passedType);

            //When
            var cell = new BoolToGridCellConverter().Convert(propertyInfoMock.Object);

            //Then
            cell.ShouldBeNull();
        }

        [Fact]
        public void Convert_WhenPassedBool_ReturnsCheckBoxCellWithCorrectBinding()
        {
            //Given
            var model = new Mock<ITestModel>();
            model.SetupGet(m => m.Bool).Returns(false);
            var property = model.Object.GetType().GetProperty(nameof(ITestModel.Bool));

            //When
            var cell = new BoolToGridCellConverter().Convert(property);

            //Then
            cell.ShouldBeOfType<CheckBoxCell>();
            cell.As<CheckBoxCell>().Binding.GetValue(model.Object).ShouldBe(false);

            model.SetupGet(m => m.Bool).Returns(true);
            cell.As<CheckBoxCell>().Binding.GetValue(model.Object).ShouldBe(true);
        }

        [Fact]
        public void Convert_WhenPassedNullableBool_ReturnsCheckBoxCellWithCorrectBinding()
        {
            //Given
            var model = new Mock<ITestModel>();
            model.SetupGet(m => m.NullableBool).Returns((bool?)null);
            var property = model.Object.GetType().GetProperty(nameof(ITestModel.NullableBool));

            //When
            var cell = new BoolToGridCellConverter().Convert(property);

            //Then
            cell.ShouldBeOfType<CheckBoxCell>();
            cell.As<CheckBoxCell>().Binding.GetValue(model.Object).ShouldBe(null);

            model.SetupGet(m => m.NullableBool).Returns(true);
            cell.As<CheckBoxCell>().Binding.GetValue(model.Object).ShouldBe(true);

            model.SetupGet(m => m.NullableBool).Returns(false);
            cell.As<CheckBoxCell>().Binding.GetValue(model.Object).ShouldBe(false);
        }
    }
}