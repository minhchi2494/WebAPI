using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    public class CustomerAttributeContext : DbContext
    {
        public CustomerAttributeContext(DbContextOptions options) : base(options) { }

        public DbSet<CustomerAttribute> CustomerAttributes { get; set; }
    }
}
