using Kursovaya.Core.Model;

namespace Kursovaya.Core.Abstract
{
    public interface ISuppliesServise
    {
        Task<Guid> CreateSupplies(Supply sup);
        Task<Guid> DeleteSupply(Guid id);
        Task<List<Supply>> GetAllSupplies();
        Task<Guid> UpdateSupply(Guid id, string name, string description, string picture, int type, double price);
    }
}