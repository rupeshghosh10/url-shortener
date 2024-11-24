namespace TinyUrl.Service.Interface;

public interface ITinyUrlService
{
    Task<string> ShortenUrl(string url);
    Task<string?> GetUrl(string key);
}