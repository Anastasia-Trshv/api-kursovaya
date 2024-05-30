using api_курсовая.Contracts;
using api_курсовая.model;
using Kursovaya.Application.Services;
using Kursovaya.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace api_курсовая.Repositories
{


    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supply>> GetCart(string id)
        {
            List<string> supIds = new List<string>();

            var userRecords = _context.ShoppingCart
                 .Where(ur => ur.UserId == id)
                 .Select(ur => ur.SupplyId)
                 .ToList();
            supIds.AddRange(userRecords);

            var sups = _context.Supplies
            .Where(s => supIds.Contains(s.Id.ToString()))
            .Select(s => Supply.Create(s.Id, s.Name, s.Description, s.Picture, s.Type, s.Price).sup)
            .ToList();

            return sups;
        }

        public async Task<string> Delete(string userid, string supId)
        {
            await _context.ShoppingCart
                .Where(s => s.UserId == userid && s.SupplyId == supId)
                .ExecuteDeleteAsync();
            return supId;
        }

        public async Task<string> AddinCart(string userid, string supId)
        {
            ShoppingCartEntity cart = new ShoppingCartEntity(userid, supId, 1);
            await _context.ShoppingCart.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart.SupplyId;

        }
    }
}
