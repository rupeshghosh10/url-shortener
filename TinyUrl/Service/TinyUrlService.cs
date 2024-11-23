using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyUrl.Data;
using TinyUrl.Models;
using TinyUrl.Service.Interface;

namespace TinyUrl.Service;

public class TinyUrlService(TinyUrlDbContext db) : ITinyUrlService
{
    public async Task<string> ShortenUrl(string url)
    {
        var hashedUrlBytes = MD5.HashData(Encoding.UTF8.GetBytes(url));
        var encodedKey = Base62Encode(hashedUrlBytes[..5]);

        if (!await UrlExists(url))
        {
            db.UrlMappings.Add(new UrlMapping
            {
                UrlKey = encodedKey,
                LongUrl = url,
                CreationDate = DateTime.UtcNow
            });
            await db.SaveChangesAsync();
        }

        return encodedKey;
    }

    public async Task<bool> UrlExists(string url)
    {
        return await db.UrlMappings.AnyAsync(x => x.LongUrl == url);
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