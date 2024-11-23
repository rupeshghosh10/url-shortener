using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TinyUrl.Models;

[Index(nameof(ShortUrl), IsUnique = true)]
public class UrlMapping
{
    public int Id { get; init; }

    [MaxLength(500)] 
    public string LongUrl { get; init; } = null!;

    [MaxLength(12)] 
    public string ShortUrl { get; init; } = null!;

    public DateTime CreationDate { get; init; }
}