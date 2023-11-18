using EntitiesLayer.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBContext
{
    public class TecUsersContextDB : DbContext
    {
        public TecUsersContextDB()
        {
                
        }

        public TecUsersContextDB(DbContextOptions<TecUsersContextDB> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Persons> Persons { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                           .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TecUsers"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

            
            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.IdPersons)
                .HasName("PK__PERSONS__2EC8D552FB5B783D");

                entity.ToTable("PERSONS");

                entity.Property(e => e.IdPersons)
                    .ValueGeneratedNever()
                    .HasColumnName("IdPersons");


                entity.Property(e => e.Names)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Names");


                entity.Property(e => e.LastNames)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LastNames");


                entity.Property(e => e.Type_Ide)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Type_Ide");

                entity.Property(e => e.Id_Number)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Id_Number");


                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.Date_Creation)
                    .IsUnicode(false)
                    .HasColumnName("Date_Creation");



                entity.Property(e => e.FullName)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("FullName");

                entity.Property(e => e.FullIdent)
                    .HasMaxLength(81)
                    .IsUnicode(false)
                    .HasColumnName("FullIdent");

            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id_Users)
                .HasName("PK__Users__FB0668EE65756CEC");

                entity.ToTable("Users");

                entity.Property(e => e.Id_Users)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Users");


                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserName");


                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pass");

                entity.Property(e => e.Creation_date)
                    .IsUnicode(false)
                    .HasColumnName("Creation_date");

                entity.HasOne(e => e.Persons)
                      .WithMany()
                      .HasForeignKey(e => e.Persons_Id)
                      .HasConstraintName("fk_Persons");

            });

            
        }

    }
}
