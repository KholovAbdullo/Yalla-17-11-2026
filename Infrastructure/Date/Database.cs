using System.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Date;

public class Database(DbContextOptions<Database> options):DbContext(options)
{
    public DbSet<Companies> Companies { get; set; }
    public DbSet<Menuitems> Menuitems { get; set; }
    public DbSet<Menus> Menus { get; set; }
    public DbSet<Orderitems> Orderitems { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }
}
