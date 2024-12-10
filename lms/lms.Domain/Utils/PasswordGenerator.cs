using System.Text;

namespace lms.Domain.Utils;

public static class PasswordGenerator
{
    public static string GenerateStrongPassword(int length = 12)
    {
        if (length < 8)
        {
            throw new ArgumentException("O comprimento mínimo para uma senha forte é 8 caracteres.");
        }

        const string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string numericChars = "0123456789";
        const string specialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~";
        const string allChars = upperCaseChars + lowerCaseChars + numericChars + specialChars;

        var random = new Random();

        var password = new StringBuilder()
            .Append(upperCaseChars[random.Next(upperCaseChars.Length)])
            .Append(lowerCaseChars[random.Next(lowerCaseChars.Length)])
            .Append(numericChars[random.Next(numericChars.Length)])
            .Append(specialChars[random.Next(specialChars.Length)]);

        for (int i = password.Length; i < length; i++)
        {
            password.Append(allChars[random.Next(allChars.Length)]);
        }

        return new string(password.ToString().OrderBy(c => random.Next()).ToArray());
    }
}
