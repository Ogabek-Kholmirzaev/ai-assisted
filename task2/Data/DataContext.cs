using Microsoft.EntityFrameworkCore;
using task2.Data.Models;

namespace task2.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
