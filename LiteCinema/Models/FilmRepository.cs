using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiteCinema.Models
{
    public class FilmRepository : Repository
    {
        private CinemaContext db;

        public FilmRepository(CinemaContext context)
        {
            this.db = context;
        }

        public IEnumerable<Film> GetAll()
        {
            return db.Films;
        }

        public Film Get(int id)
        {
            return db.Films.Find(id);
        }

        public void Create(Film film)
        {
            db.Films.Add(film);
        }

        public void Update(Film film)
        {
            db.Entry(film).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Film film = db.Films.Find(id);
            if (film != null)
                db.Films.Remove(film);
        }
    }
}
