using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_курсовая.Repositories;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;

namespace Kursovaya.Application.Services
{
   

    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Supply>> GetCart(string id)
        {
            return await _repository.GetCart(id);
        }
        public async Task<string> DeleteSup(string userid, string supId)
        {
            return await _repository.Delete(userid, supId);
        }
        public async Task<string> AddSupply(string userid, string supId)
        {
            return await _repository.AddSupply(userid, supId);
        }



    }
}
