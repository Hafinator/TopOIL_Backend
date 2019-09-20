using Microsoft.EntityFrameworkCore;
using TopOIL_Backend.Models;

namespace TopOIL_Backend
{
    public interface IDbContext
    {
        DbSet<OilField> OilFields { get; set; }
        int SaveChanges();
        void Remove(OilField oilField);
    }
    public class Context : DbContext, IDbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
        public Context()
        { }

        public DbSet<OilField> OilFields { get; set; }

        public new void Remove(OilField oilField) => base.Remove(oilField);
    }
}
