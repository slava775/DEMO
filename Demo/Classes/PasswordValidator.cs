using System.Text.RegularExpressions;

namespace Demo.Classes
{
    public class PasswordValidator
    {
        public static string CheckPasswordStrength(string password)
        {
            if (password.Length < 5 || password.Length > 15)
            {
                return "Пароль должен быть от 5 до 15 символов";
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return "Пароль должен содержать хотя бы одну заглавную букву";
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                return "Пароль должен содержать хотя бы одну строчную букву";
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return "Пароль должен содержать хотя бы одну цифру";
            }

            if (!Regex.IsMatch(password, "[!@#$%^&*()_+=\\-\\[\\]{};':\"\\\\|,.<>\\/?]"))
            {
                return "Пароль должен содержать хотя бы один спецсимвол (!@#$%^&*()_+ и т.д.)";
            }

            return null;
        }
    }
}
