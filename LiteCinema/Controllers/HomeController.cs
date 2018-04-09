using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteCinema.Models;
using Microsoft.EntityFrameworkCore;
//using System.Web;
//using System.Web.Mvc;

namespace LiteCinema.Controllers
{

        public class HomeController : Controller
        {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var film = unitOfWork.Films.GetAll();
            //return RedirectToAction("Index");
            return View("Index", new List<Film>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film f)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Films.Create(f);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(f);
        }

        public ActionResult Edit(int id)
        {
            Film f = unitOfWork.Films.Get(id);
            if (f == null) 
               throw new Exception("404, Not found");
            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(Film f)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Films.Update(f);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(f);
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Films.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }






        /*CinemaContext db;
            public HomeController(CinemaContext context)
            {
                db = context;
            }
            public IActionResult Index()
            {
                return View(db.Films.ToList());
            }*/


        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.FilmId = id;
            return RedirectToAction("Buy");
        }

        [HttpPost]
        public ActionResult Create(Ticket t)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Tickets.Create(t);
                unitOfWork.Save();
                //return "Thx, " + t.Buyer + ", for the buying!";
                return RedirectToAction("Index");
            }
            return View(t);
            //return View(t);

            //return "Thx, " + t.Buyer + ", for the buying!";
        }




        /*[HttpPost]
        public string Buy(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            // save changes in db
            db.SaveChanges();
            return "Спасибо, " + ticket.Buyer + ", за покупку!";
        }*/
    }
}