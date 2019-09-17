using Microsoft.EntityFrameworkCore;
using TopOIL_Backend.Models;

namespace TopOIL_Backend
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
        public DbSet<OilField> OilFields { get; set; }
    }
}
