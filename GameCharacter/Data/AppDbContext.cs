using GameCharacter.Models;
using Microsoft.EntityFrameworkCore;

namespace GameCharacter.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)  :DbContext(options)
{
    public DbSet<Models.Character> characters => Set<Character>();
    
    
}