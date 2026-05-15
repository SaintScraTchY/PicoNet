using PicoNet.Domain.Entities.Common.Concrete;

namespace PicoNet.Domain.Events;

public record UrlCreatedDomainEvent(
    Guid UrlId,
    string ShortCode,
    string OriginalUrl,
    Guid? UserId) : DomainEvent;