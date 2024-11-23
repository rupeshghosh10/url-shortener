using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using TinyUrl.Service.Interface;

namespace TinyUrl.Service;

public class TinyUrlService : ITinyUrlService
{
    public string ShortenUrl(string url)
    {
        var hashedUrlBytes = SHA256.HashData(Encoding.UTF8.GetBytes(url));
        return Base62Encode(hashedUrlBytes[..5]);
    }

    private static string Base62Encode(byte[] bytes)
    {
        const string base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var base62String = new StringBuilder();
        var value = new BigInteger(bytes);

        if (value < 0)
        {
            value = BigInteger.Negate(value);
        }

        while (value > 0)
        {
            base62String.Insert(0, base62Chars[(int)(value % 62)]);
            value /= 62;
        }

        while (base62String.Length < 6)
        {
            base62String.Insert(0, base62Chars[0]);
        }

        return base62String.ToString();
    }
}