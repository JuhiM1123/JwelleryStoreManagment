using JwelleryStore.Common.Model;
using JwelleryStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwelleryStore.DAL
{
    public class JwelleryStoreDBContext : DbContext
    {
        public JwelleryStoreDBContext(DbContextOptions<JwelleryStoreDBContext> options) : base(options)
        {

        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>()
            .HasIndex(u => new { u.UserName, u.Password }, "IX_UserName_Password").IsUnique();

            modelBuilder.Entity<Role>()
            .HasIndex(r => new { r.RoleName }, "IX_RoleName").IsUnique();

            modelBuilder.Entity<Role>()
                .HasData(
                      new { RoleId = 1, RoleName = "Normal" },
                      new { RoleId = 2, RoleName = "Privileged", DiscountPrice = 2.0 }
                );

            modelBuilder.Entity<UserDetail>()
              .HasData(
                 new { UserDetailId = 1, FirstName = "Stuart", LastName = "Smith", UserName = "normalUser", Password = "0wTTRNFbR9GU7ezGKUnamw==", RoleId = 1 },
                 new { UserDetailId = 2, FirstName = "Bill", LastName = "Clinton", UserName = "privilegedUser", Password = "kwRhRldxFNP0kMa/5doNhg==", RoleId = 2 }
              );

            
        }
    }
}
