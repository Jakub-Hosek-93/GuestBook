using GuestBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBookAPI.Data;

public class GuestBookContext : DbContext
{
    public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
    {
    }
    
    public DbSet<RecordModel> records { get; set; }
}