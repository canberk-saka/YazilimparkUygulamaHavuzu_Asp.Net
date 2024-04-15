using Microsoft.EntityFrameworkCore;
using UygulamaHavuzu.Web.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoModel> ToDo { get; set; }
}