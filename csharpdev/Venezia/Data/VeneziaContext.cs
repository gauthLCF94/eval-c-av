using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Venezia.Models;

namespace Venezia.Data
{
    public class VeneziaContext : DbContext
    {
        public static readonly ILoggerFactory SqlLogger = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public VeneziaContext (DbContextOptions<VeneziaContext> options)
            : base(options)
        {
        }

        public DbSet<Venezia.Models.Car> Car { get; set; }

        public DbSet<Venezia.Models.Fuel> Fuel { get; set; }
    }
}
