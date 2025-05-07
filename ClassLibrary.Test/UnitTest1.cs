using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class CpfValidatorTests
    {
        private readonly CpfValidator _validator = new CpfValidator();

        [TestMethod]
        public void IsValid_ValidCpf_ReturnsTrue()
        {
            // Arrange
            string validCpf = "123.456.789-09"; // Substitua por um CPF válido real

            // Act
            bool result = _validator.IsValid(validCpf);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_InvalidCpf_ReturnsFalse()
        {
            // Arrange
            string invalidCpf = "123.456.789-00";

            // Act
            bool result = _validator.IsValid(invalidCpf);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_EmptyCpf_ReturnsFalse()
        {
            // Arrange
            string emptyCpf = "";

            // Act
            bool result = _validator.IsValid(emptyCpf);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_CpfWithAllSameDigits_ReturnsFalse()
        {
            // Arrange
            string sameDigitsCpf = "111.111.111-11";

            // Act
            bool result = _validator.IsValid(sameDigitsCpf);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_CpfWithInvalidCharacters_ReturnsFalse()
        {
            // Arrange
            string invalidCpf = "123.abc.789-09";

            // Act
            bool result = _validator.IsValid(invalidCpf);

            // Assert
            Assert.IsFalse(result);
        }
    }
}