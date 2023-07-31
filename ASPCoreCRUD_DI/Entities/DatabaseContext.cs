using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using ASPCoreCRUD_DI.Entities.Models;

namespace ASPCoreCRUD_DI.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
    }
}
