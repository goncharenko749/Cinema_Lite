using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiteCinema.Models
{
    public class UnitOfWork : IDisposable
    {
            private CinemaContext db = new CinemaContext();
            private FilmRepository filmRepository;
            private TicketRepository ticketRepository;

            public FilmRepository Films
            {
                get
                {
                    if (filmRepository == null)
                        filmRepository = new FilmRepository(db);
                    return filmRepository;
                }
            }

            public TicketRepository Tickets
            {
                get
                {
                    if (ticketRepository == null)
                        ticketRepository = new TicketRepository(db);
                    return ticketRepository;
                }
            }

            public void Save()
            {
                db.SaveChanges();
            }

            private bool disposed = false;

            public virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    this.disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
}
