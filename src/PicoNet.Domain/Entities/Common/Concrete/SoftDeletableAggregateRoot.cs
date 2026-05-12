using PicoNet.Domain.Entities.Common.Interfaces;

namespace PicoNet.Domain.Entities.Common.Concrete;

public abstract class SoftDeletableAggregateRoot<TId> : AuditableAggregateRoot<TId>, ISoftDelete 
    where TId : notnull
{
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    
    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}