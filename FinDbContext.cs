using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_ApiApp.Models
{
/// <summary>
/// The class for Performing DB Transactions using EFCore and Table Mapping
/// </summary>
    public class FinDbContext : DbContext
    {
        // define properties for DbTable Mapping
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// The ctor will read the DbContext Registered Service (?) for the
        /// Current application and establish DbConnection and Table Mapping
        /// </summary>
        /// <param name="options"></param>
        public FinDbContext(DbContextOptions<FinDbContext> options):base(options)
        {

        }
    }
}
