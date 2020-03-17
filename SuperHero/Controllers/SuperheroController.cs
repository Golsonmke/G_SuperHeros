using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class SuperheroController : Controller
    {
        public ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var superHero = _context.SuperHeroes;
            return View(superHero);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int Id)
        {
             Superhero superHero = _context.SuperHeroes.Find(Id);
            return View(superHero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                
                _context.SuperHeroes.Add(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.SuperHeroes.Find(id);
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                Superhero superheroEdit = _context.SuperHeroes.Find(id);             
                superheroEdit.Name = superhero.Name;
                superheroEdit.AlterEgo = superhero.AlterEgo;
                superheroEdit.SuperPower = superhero.SuperPower;
                superheroEdit.SecondarySuperPower = superhero.SecondarySuperPower;
                superheroEdit.CatchPhrase = superhero.CatchPhrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _context.SuperHeroes.Find(id);
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                Superhero superheroDelete = _context.SuperHeroes.Find(id);
                _context.SuperHeroes.Remove(superheroDelete);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}