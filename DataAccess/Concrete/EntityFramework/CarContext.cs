using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class CarContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarDb;Trusted_Connection=True;");
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Entities.Concrete.Color> Colors { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Rental> Rentals { get; set; }
    
    public  DbSet<CarImage> CarImages { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
}