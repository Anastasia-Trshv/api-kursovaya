using Kursovaya.Core.Model;

namespace Kursovaya.Core.Abstract
{
    public interface ISupplyRepository
    {
        Task<List<Supply>> Get();
        Task<Guid> Create(Supply supply);
        Task<Guid> Update(Guid id, string name, string description, string picture, int type, double price);
        Task<Guid> Delete(Guid id);
    }
}