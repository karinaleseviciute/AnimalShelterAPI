using AnimalShelterAPI.AnimalDomain.Models;
using AnimalShelterAPI.UserDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelterAPI.Data
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Animal>()
        //        .HasOne(p => p.User)
        //        .WithMany(b => b.Animals)
        //        .IsRequired();

        //    modelBuilder.Entity<User>()
        //        .HasMany(p => p.Animals)
        //        .WithOne(b => b.User);

        //    modelBuilder.Entity<User>()
        //        .HasOne(p => p.Contact);               

        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}

