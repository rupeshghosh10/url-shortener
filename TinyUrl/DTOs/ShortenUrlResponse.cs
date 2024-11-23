namespace TinyUrl.DTOs;

public class ShortenUrlResponse
{
    public string Key { get; set; } = null!;
    
    public string ShortUrl { get; set; } = null!;
    
    public string LongUrl { get; set; } = null!;
}