using MeatOrderSystem.Model.Entities;

public interface IMeatOriginRepository
{
    Task<IEnumerable<MeatOrigin>> GetAllAsync();
}