using Bankmngsys.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bankmngsys
{
    public class Dbcon : DbContext
    {
        public Dbcon(DbContextOptions<Dbcon> options) 
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
