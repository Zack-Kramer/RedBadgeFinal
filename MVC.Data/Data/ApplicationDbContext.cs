using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;

namespace MVC_IndividualAuthentication.Data.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<CardBase> CardBases { get; set; }
    public DbSet<CardTable> CardTables { get; set; }
    public DbSet<Creature> Creatures { get; set;  }
    public DbSet<LandTable> LandTables { get; set; }
    public DbSet<User> Users { get; set; }

    


}

