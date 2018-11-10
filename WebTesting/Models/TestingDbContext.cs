using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTesting.Models
{
    public class TestingDbContext : DbContext
    {
        public TestingDbContext(DbContextOptions<TestingDbContext> options)
            : base(options)
        {

        }

        public DbSet<Products> Productos { get; set; }
    }
}
