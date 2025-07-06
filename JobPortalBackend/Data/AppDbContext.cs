using JobPortalBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalBackend.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
    
    public DbSet<Job> Jobs { get; set; }
}