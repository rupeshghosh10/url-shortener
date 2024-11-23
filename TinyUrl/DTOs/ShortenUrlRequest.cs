using System.ComponentModel.DataAnnotations;

namespace TinyUrl.DTOs;

public class ShortenUrlRequest
{
    [Url]
    [MaxLength(500)]
    public string Url { get; set; } = null!;
}