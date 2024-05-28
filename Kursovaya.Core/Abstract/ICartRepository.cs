﻿using Kursovaya.Core.Model;

namespace api_курсовая.Repositories
{
    public interface ICartRepository
    {
        Task<string> AddSupply(string userid, string supId);
        Task<string> Delete(string userid, string supId);
        Task<List<Supply>> GetCart(string id);
    }
}