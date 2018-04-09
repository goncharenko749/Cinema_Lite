using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiteCinema.Models
{
    public class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //work but don't(?) nedeed for unit of work
        /*public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {

        }*/


        
    }
}
