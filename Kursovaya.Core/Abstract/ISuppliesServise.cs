using Kursovaya.Core.Model;

namespace Kursovaya.Core.Abstract
{
    public interface ISuppliesServise
    {
        Task<int> CreateSupplies(Supply sup);
        Task<int> DeleteSupply(int id);
        Task<List<Supply>> GetAllSupplies();
        Task<int> UpdateSupply(int id, string name, string description, string picture, int type, double price);
    }
}