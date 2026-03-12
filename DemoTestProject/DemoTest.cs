using Demo.Classes;

namespace DemoTestProject
{
    [TestClass]
    public sealed class DemoTest
    {
        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsNull()
        {
            string password = "Slava123!";
            string expectedError = null;

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.IsNull(result, expectedError);
        }

        [TestMethod]
        public void ValidatePassword_TooShortPassword_ReturnsErrorMessage()
        {
            string password = "Sl1!";
            string expectedError = "Пароль должен быть от 5 до 15 символов";

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.AreEqual(expectedError, result);
        }

        [TestMethod]
        public void ValidatePassword_TooLongPassword_ReturnsErrorMessage()
        {
            string password = "Slava12345678910!";
            string expectedError = "Пароль должен быть от 5 до 15 символов";

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.AreEqual(expectedError, result);
        }

        [TestMethod]
        public void ValidatePassword_ValidatePassword_NoUpperCase_ReturnsErrorMessage()
        {
            string password = "slava123!";
            string expectedError = "Пароль должен содержать хотя бы одну заглавную букву";

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.AreEqual(expectedError, result);
        }

        [TestMethod]
        public void ValidatePassword_ValidatePassword_NoLowerCase_ReturnsErrorMessage()
        {
            string password = "SLAVA123!";
            string expectedError = "Пароль должен содержать хотя бы одну строчную букву";

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.AreEqual(expectedError, result);
        }

        [TestMethod]
        public void ValidatePassword_ValidatePassword_NoNumber_ReturnsErrorMessage()
        {
            string password = "Slava!!!";
            string expectedError = "Пароль должен содержать хотя бы одну цифру";

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.AreEqual(expectedError, result);
        }

        [TestMethod]
        public void ValidatePassword_ValidatePassword_NoSpecialChar_ReturnErrorMessage()
        {
            string password = "Slava123";
            string expectedError = "Пароль должен содержать хотя бы один спецсимвол (!@#$%^&*()_+ и т.д.)";

            string result = PasswordValidator.CheckPasswordStrength(password);
            Assert.AreEqual(expectedError, result);
        }
    }
}
