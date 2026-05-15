using PicoNet.Domain.Entities.Common.Concrete;

namespace PicoNet.Domain.Entities;

public class UrlVisit : Entity<Guid>
{
    public Guid ShortenedUrlId { get; private set; }
    public string? IpAddress { get; private set; }
    public string? UserAgent { get; private set; }
    public string? Referrer { get; private set; }
    public string? Country { get; private set; }
    public DateTime VisitedAt { get; private set; }
    
    // Navigation
    public ShortenedUrl ShortenedUrl { get; private set; } = null!;
    
    private UrlVisit() { }
    
    public static UrlVisit Create(
        Guid shortenedUrlId, 
        string? ipAddress, 
        string? userAgent, 
        string? referrer, 
        string? country)
    {
        return new UrlVisit
        {
            Id = Guid.NewGuid(),
            ShortenedUrlId = shortenedUrlId,
            IpAddress = ipAddress,
            UserAgent = userAgent,
            Referrer = referrer,
            Country = country,
            VisitedAt = DateTime.UtcNow
        };
    }
}