using System.Security.Cryptography;
using System.Text;

namespace LivroDeReceitas.Application.Services.Cryptography;

public class PasswordEncripter
{
    public string Encrypt(string password)
    {
        var aditionalKey = "qualquerstringaqui";

        var newPassword = $"{password}{aditionalKey}";

        var bytes = Encoding.UTF8.GetBytes(newPassword);

        var hashBytes = SHA512.HashData(bytes);

        return StringBytes(hashBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(b);
        }

        return sb.ToString();
    }
}