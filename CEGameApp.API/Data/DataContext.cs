using CEGameApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CEGameApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base
        (options){}

        public DbSet<Users> Users { get; set; }
    }
}