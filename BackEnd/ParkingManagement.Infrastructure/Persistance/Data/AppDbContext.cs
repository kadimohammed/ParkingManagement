using Microsoft.EntityFrameworkCore;
using ParkingManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Infrastructure.Persistance.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ArtisanWorkDay> ArtisanWorkDays { get; set; }
        public DbSet<Artisan> Artisans { get; set; }
        public DbSet<ArtisanClientService> ArtisanClientServices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientParking> ClientParkings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ArtisanImage> ArtisanImages { get; set; }
        public DbSet<Parking> parkings { get; set; }
        public DbSet<ParkingDay> ParkingDays { get; set; }
        public DbSet<ArtisanType> ArtisanTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
