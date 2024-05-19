using Kursovaya.Core.Model;

namespace Kursovaya.Core.Abstract
{
    public interface ISupplyRepository
    {
        Task<List<Supply>> Get();
        Task<int> Create(Supply supply);
        Task<int> Update(int id, string name, string description, string picture, int type, double price);
        Task<int> Delete(int id);
    }
}