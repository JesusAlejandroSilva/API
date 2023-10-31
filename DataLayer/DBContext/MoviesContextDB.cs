using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBContext
{
    public class MoviesContextDB: DbContext
    {
        public MoviesContextDB()
        {
                
        }

        public MoviesContextDB(DbContextOptions<MoviesContextDB> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Movies> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                           .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TestXamarin"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

            //Movies
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK__Movies__3214EC0752FF94D0");

                entity.ToTable("Movies");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");


                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Title");


                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description");


                entity.Property(e => e.launch_date)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("launch_date");

                entity.Property(e => e.score)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("score");


            });
        }

    }
}
