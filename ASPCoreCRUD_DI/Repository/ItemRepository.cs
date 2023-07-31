using ASPCoreCRUD_DI.Entities;
using ASPCoreCRUD_DI.Entities.Models;
using ASPCoreCRUD_DI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ASPCoreCRUD_DI.Repository
{
    public class ItemRepository : IItem
    {
        readonly DatabaseContext _dbContext = new();

        public ItemRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> Get()
        {
            try
            {
                return await _dbContext.Items.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Item?> Get(int id)
        {
            try
            {
                return await _dbContext.Items.FirstOrDefaultAsync(m => m.ID == id);
            }
            catch
            {
                throw;
            }
        }

        public void Create(Item model)
        {
            try
            {
                _dbContext.Items.Add(model);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Item model)
        {
            try
            {
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Item Delete(int id)
        {
            try
            {
                Item? item = _dbContext.Items.Find(id);

                if (item != null)
                {
                    _dbContext.Items.Remove(item);
                    _dbContext.SaveChanges();
                    return item;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckExists(int id)
        {
            return _dbContext.Items.Any(e => e.ID == id);
        }
    }
}
