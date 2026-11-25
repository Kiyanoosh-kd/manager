namespace Entities.common;


public abstract class BaseEntity<TId>
{
    public TId Id { get; set; } = default!;
}
