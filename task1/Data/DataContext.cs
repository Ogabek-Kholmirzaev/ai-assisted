using Microsoft.EntityFrameworkCore;
using task1.Data.Models;

namespace task1.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ToDo> ToDos { get; set; }
}