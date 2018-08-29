using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace imaginaryPortal.Models
{
    public class imaginaryDbContext:DbContext
    {
        public imaginaryDbContext()
        : base("name=imaginaryPortal")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}