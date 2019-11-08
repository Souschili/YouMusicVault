using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User {get;set;}
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

}
}
