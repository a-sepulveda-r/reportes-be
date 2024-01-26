using Microsoft.EntityFrameworkCore;

namespace Reactaspcrud.Models
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }
        public DbSet<Report> Report { get; set; }
    }
}
