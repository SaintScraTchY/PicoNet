using PicoNet.Domain.Entities;

namespace PicoNet.Domain.Interfaces;

public interface IUrlRepository
{
    Task<ShortenedUrl?> GetByNanoIdAsync(string nanoId, CancellationToken ct = default);
    Task<ShortenedUrl?> GetActiveByNanoIdAsync(string nanoId, CancellationToken ct = default);
    Task<IReadOnlyList<ShortenedUrl>> GetUserUrlsAsync(Guid userId, CancellationToken ct = default);
    Task<bool> IsNanoIdUniqueAsync(string nanoId, CancellationToken ct = default);
    Task AddAsync(ShortenedUrl url, CancellationToken ct = default);
    Task UpdateAsync(ShortenedUrl url, CancellationToken ct = default);
    Task SoftDeleteAsync(Guid id, CancellationToken ct = default);
}