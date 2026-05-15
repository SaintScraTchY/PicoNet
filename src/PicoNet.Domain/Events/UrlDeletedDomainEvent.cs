using PicoNet.Domain.Entities.Common.Concrete;

namespace PicoNet.Domain.Events;

public record UrlDeactivatedDomainEvent(
    Guid UrlId,
    string ShortCode) : DomainEvent;    