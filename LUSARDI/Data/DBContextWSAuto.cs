using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUSARDI.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LUSARDI.Data
{
    public class DBContextWSAuto : DbContext
    {
        public DBContextWSAuto(DbContextOptions<DBContextWSAuto> options) : base(options) { }

        public DbSet<Auto> Vehiculo { get; set; }
    }
}
