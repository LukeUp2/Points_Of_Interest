using Microsoft.EntityFrameworkCore;
using Points_Of_Interest.Api.Models;

namespace Points_Of_Interest.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PointsOfInterest> Points_Of_Interests { get; set; }
    }
}