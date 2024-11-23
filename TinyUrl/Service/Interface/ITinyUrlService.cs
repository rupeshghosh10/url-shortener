namespace TinyUrl.Service.Interface;

public interface ITinyUrlService
{
    Task<string> ShortenUrl(string url);
    Task<bool> UrlExists(string url);
}