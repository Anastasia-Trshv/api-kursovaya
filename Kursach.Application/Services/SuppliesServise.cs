using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Application.Services
{
    public class SuppliesServise : ISuppliesServise
    {
        private readonly ISupplyRepository _supplyRepository;
        public SuppliesServise(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public async Task<List<Supply>> GetAllSupplies()
        {
            return await _supplyRepository.Get();
        }
        public async Task<Guid> CreateSupplies(Supply sup)
        {
            return await _supplyRepository.Create(sup);
        }
        public async Task<Guid> UpdateSupply(Guid id, string name, string description, string picture, int type, double price)
        {
            return await _supplyRepository.Update(id, name, description, picture, type, price);
        }
        public async Task<Guid> DeleteSupply(Guid id)
        {
            return await _supplyRepository.Delete(id);
        }
    }
}
