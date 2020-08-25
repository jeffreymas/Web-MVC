using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(): base("MyConnection")
        {
            
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Division> Division { get; set; }
    }
}