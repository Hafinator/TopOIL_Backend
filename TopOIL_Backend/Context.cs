using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TopOIL_Backend
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
    }
}
