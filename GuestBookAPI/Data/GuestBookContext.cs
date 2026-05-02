using GuestBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBookAPI.Data;

public class GuestBookContext : DbContext
{
    public DbSet<RecordModel> records { get; set; }
}