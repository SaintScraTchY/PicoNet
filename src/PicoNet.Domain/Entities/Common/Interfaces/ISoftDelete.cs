namespace PicoNet.Domain.Entities.Common.Interfaces;

public interface ISoftDelete
{
    bool IsDeleted { get; }
    DateTime? DeletedAt { get; }
}