using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TinyUrl.Models;

[Index(nameof(UrlKey), nameof(LongUrl), IsUnique = true)]
public class UrlMapping
{
    public int Id { get; init; }

    [MaxLength(500)] 
    public string LongUrl { get; init; } = null!;

    [MaxLength(12)] 
    public string UrlKey { get; init; } = null!;

    public DateTime CreationDate { get; init; }
}