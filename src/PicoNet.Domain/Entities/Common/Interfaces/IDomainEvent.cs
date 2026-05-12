namespace PicoNet.Domain.Entities.Common.Interfaces;

public interface IDomainEvent
{
    DateTime OccurredAt { get; } 
}