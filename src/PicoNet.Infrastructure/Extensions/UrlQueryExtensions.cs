// PicoNet.Infrastructure/Extensions/UrlQueryExtensions.cs
using Microsoft.EntityFrameworkCore;
using PicoNet.Domain.Entities;

namespace PicoNet.Infrastructure.Extensions;

public static class UrlQueryExtensions
{
    /// <summary>
    /// Full-text search using PostgreSQL's to_tsvector and to_tsquery functions
    /// </summary>
    public static IQueryable<ShortenedUrl> WhereMatches(
        this IQueryable<ShortenedUrl> query, 
        string searchTerm)
    {
        // Sanitize search term for tsquery
        var sanitized = searchTerm?
            .Replace("'", "''")
            .Replace("&", "")
            .Replace("|", "")
            .Replace("!", "");
        
        if (string.IsNullOrWhiteSpace(sanitized))
            return query;
        
        // Create tsquery from search term (supports & for AND, | for OR)
        var tsQuery = string.Join(" & ", 
            sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => $"{word}:*")); // :* for prefix matching
        
        return query.Where(u => 
            EF.Functions.ToTsVector("english", u.OriginalUrl + " " + u.CustomAlias + " " + u.Tags)
                .Matches(EF.Functions.ToTsQuery("english", tsQuery)));
    }
    
    /// <summary>
    /// Simple LIKE-based search as fallback
    /// </summary>
    public static IQueryable<ShortenedUrl> WhereContains(
        this IQueryable<ShortenedUrl> query, 
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return query;
        
        var pattern = $"%{searchTerm}%";
        
        return query.Where(u => 
            EF.Functions.ILike(u.OriginalUrl, pattern) ||
            (u.CustomAlias != null && EF.Functions.ILike(u.CustomAlias, pattern)) ||
            (u.Tags != null && EF.Functions.ILike(u.Tags, pattern)));
    }
    
    public static IQueryable<ShortenedUrl> WhereActive(this IQueryable<ShortenedUrl> query)
        => query.Where(u => u.Status == Domain.Enums.UrlStatus.Active && !u.IsDeleted);
    
    public static IQueryable<ShortenedUrl> WhereUser(this IQueryable<ShortenedUrl> query, Guid userId)
        => query.Where(u => u.UserId == userId);
}