using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Models
{
    public class AirlineDbContext:DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options):base(options)
        { }
        public DbSet<AirLine> Airline { get; set; }
        public DbSet<FlightShedule> FlightShedule { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
    }
}
