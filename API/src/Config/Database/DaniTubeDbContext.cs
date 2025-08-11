using Microsoft.EntityFrameworkCore;
using src.Features.Users;

namespace src.Config.Database;

public class DaniTubeDbContext(DbContextOptions<DaniTubeDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}