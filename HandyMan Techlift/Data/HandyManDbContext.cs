using HandyMan_Techlift.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HandyMan_Techlift.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace HandyMan_Techlift.Data
{
    public class HandyManDbContext : IdentityDbContext<IdentityUser>
    {
        public HandyManDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<Services> tblservice { get; set; }
        public DbSet<Orders> tblOrders { get; set; }

        


    }
}