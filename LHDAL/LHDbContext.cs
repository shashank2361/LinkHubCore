using LHBOL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LHDAL
{
    public class LHDbContext:IdentityDbContext
    {

        public LHDbContext(DbContextOptions<LHDbContext> options) : base(options)
        {

              Database.EnsureCreated();
            //Database.EnsureDeleted();
            //Database.Migrate();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //     optionsBuilder.UseSqlServer(@"Server=DESKTOP-SB3UMDG;Initial Catalog=LinkHubDataBase;Integrated Security= True");
        //    base.OnConfiguring(optionsBuilder); 
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<LHUser> LHUsers { get; set; }
        public DbSet<LHUrl> LHUrls { get; set; }


    }
}
