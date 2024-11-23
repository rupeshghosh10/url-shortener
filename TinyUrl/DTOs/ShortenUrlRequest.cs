using System.ComponentModel.DataAnnotations;

namespace TinyUrl.DTOs;

public class ShortenUrlRequest
{
    [MaxLength(500)]
    public string Url { get; set; } = null!;
}