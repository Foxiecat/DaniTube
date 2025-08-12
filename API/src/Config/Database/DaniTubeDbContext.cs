using Microsoft.EntityFrameworkCore;
using src.Features.Users;
using src.Features.Users.Entities;
using src.Features.Users.Models;

namespace src.Config.Database;

public class DaniTubeDbContext(DbContextOptions<DaniTubeDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}