using api_курсовая.model;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace api_курсовая.Repositories
{
    public class SupplyRepository :ISupplyRepository
    {
        private readonly AppDbContext _context;

        public SupplyRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Supply>> Get()
        {
            var suppliesEntities = await _context.Supplies
                .AsNoTracking()
                .ToListAsync();
            var supplies = suppliesEntities
                .Select(s => Supply.Create(s.Id,s.Name,s.Description,s.Picture,s.Type,s.Price).sup)
                .ToList();
            return supplies;
        }

        public async Task<Guid> Create(Supply supply)
        {
            SupplyEntity newsupply = new SupplyEntity(supply.Id,supply.Name,supply.Description,supply.Picture,supply.Type,supply.Price);
            await _context.Supplies.AddAsync(newsupply);
            await _context.SaveChangesAsync();
            return newsupply.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description, string picture, int type, double price)
        {
            await _context.Supplies
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.Name, s => name)
                .SetProperty(s => s.Description, s => description)
                .SetProperty(s => s.Price, s => price)
                .SetProperty(s => s.Picture, s => picture)
                .SetProperty(s => s.Type, s => type));
                
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Supplies
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
