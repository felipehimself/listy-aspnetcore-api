using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.Category;
using Api.Domain.Entities.List;
using Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }


        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ListEntity> Lists { get; set; }
        public DbSet<ListItemEntity> ListItems { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Lists)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ListEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ListEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.Lists);

            modelBuilder.Entity<ListEntity>()
                .HasMany(x => x.ListItems)
                .WithOne(x => x.List);

            modelBuilder.Entity<ListItemEntity>()
                .HasKey(x => x.Id);


            modelBuilder.Entity<ListItemEntity>()
                .ToTable("list_items");

            // modelBuilder.Entity<ListItemEntity>()
            //     .HasKey(x => x.Id);

            // modelBuilder.Entity<ListItemEntity>()
            //     .HasOne(x => x.List);

            modelBuilder.Entity<CategoryEntity>()
                .HasKey(x => x.Id);




        }

    }
}