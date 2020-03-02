using Microsoft.EntityFrameworkCore;
using AuthNet.Models;

namespace AuthNet
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options){}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}