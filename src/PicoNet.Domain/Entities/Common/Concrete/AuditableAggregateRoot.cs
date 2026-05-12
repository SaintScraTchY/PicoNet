using PicoNet.Domain.Entities.Common.Interfaces;

namespace PicoNet.Domain.Entities.Common.Concrete;

public abstract class AuditableAggregateRoot<TId> : AggregateRoot<TId>, IAuditable 
    where TId : notnull
{
    public DateTime CreatedAt { get; internal set; }
    public Guid CreatedBy { get; internal set; }
    public DateTime? UpdatedAt { get; internal set; }
    public Guid? UpdatedBy { get; internal set; }
}