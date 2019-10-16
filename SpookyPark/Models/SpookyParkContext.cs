  
using Microsoft.EntityFrameworkCore;

namespace SpookyPark.Models
{
  public class SpookyParkContext : DbContext
  {
    public virtual DbSet<EntertainmentType> EntertainmentTypes { get; set; }
    public DbSet<Attraction> Attractions { get; set; }
    
    public SpookyParkContext(DbContextOptions options) : base(options) { }
  }
}