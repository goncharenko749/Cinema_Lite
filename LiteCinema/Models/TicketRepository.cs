using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiteCinema.Models
{
    public class TicketRepository
    {
        private CinemaContext db;

        public TicketRepository(CinemaContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets.Include(o => o.Film);
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public void Create(Ticket ticket)
        {
            db.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket != null)
                db.Tickets.Remove(ticket);
        }
    }
}
