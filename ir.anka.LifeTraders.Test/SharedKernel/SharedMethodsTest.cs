using FluentAssertions;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using Moq;
using static ir.anka.LifeTraders.Test.SharedKernel.SharedMethodsTestCases;

namespace ir.anka.LifeTraders.Test.SharedKernel;

public class SharedMethodsTest
{
    public class ValidatorTest
    {
        [Fact]
        public void TestCheckPropertiesValueBasedOnRangeAttribute()
        {
            var dummyClass = new DummyClass(33.22, DateTime.Now, "FarazLoloei", 213);
            var typesShouldBeChecked = new Type[] { typeof(int), typeof(double) };
            var validatorMockResult = new List<PropertyDoesNotHasValidValueException>() {
                new PropertyDoesNotHasValidValueException("CommissionPercentage", 0, 100) };

            var validatorMock = CreateValidatorMockAndSetupIt(dummyClass, typesShouldBeChecked, validatorMockResult);

            var result = validatorMock.Object.CheckPropertiesValueBasedOnRangeAttribute(dummyClass, typesShouldBeChecked);
            TestCheckPropertiesValueBasedOnRangeAttribute_Assertation(validatorMockResult, result);
        }

        private static Mock<ISharedValidator> CreateValidatorMockAndSetupIt(DummyClass dummyClass, Type[] typesShouldBeChecked, List<PropertyDoesNotHasValidValueException> result)
        {
            var validatorMock = new Mock<ISharedValidator>();

            validatorMock.Setup(m => m.CheckPropertiesValueBasedOnRangeAttribute(dummyClass, typesShouldBeChecked))
                .Returns(result);
            return validatorMock;
        }

        private static void TestCheckPropertiesValueBasedOnRangeAttribute_Assertation(List<PropertyDoesNotHasValidValueException> validatorMockResult, IEnumerable<PropertyDoesNotHasValidValueException> result)
        {
            validatorMockResult.Should().NotBeNull();
            validatorMockResult.Should().BeEquivalentTo(result);
        }

        [Theory]
        [InlineData("192.168.1.1", true)]
        [InlineData("52.18.32.194", true)]
        [InlineData("392.168.1.1", false)]
        [InlineData("552.18.32.194", false)]
        public void TestIsValidIPAddress4(string ipAddress, bool expected)
        {
            var result = (new SharedValidator()).IsValidIPAddress4(ipAddress);

            result.Should().Be(expected);
        }

    }
}