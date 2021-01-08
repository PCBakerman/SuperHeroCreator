using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero_Creator.Data;
using Superhero_Creator.Models;

namespace Superhero_Creator.Controllers
{
    public class SuperHeroController : Controller
    {
        private ApplicationDbContext _context;
        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
           
        }
        // GET: SuperHeroController
        public ActionResult Index()
        {
            var superheros = _context.SuperHeroEntries.ToList();
            return View("Index", superheros);
        }

        // GET: SuperHeroController/Details/5
        public ActionResult Details()
        {
            
            return View("Details");
        }

        // GET: SuperHeroController/Create
        public ActionResult Create()
        {
            
            return View("Create");
        }

        // POST: SuperHeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {   //TODO: Add insert logic here
                _context.SuperHeroEntries.Add(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View("Index", superHero);
            }
        }

        // GET: SuperHeroController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.SuperHeroEntries.FirstOrDefault(x => x.ID == id);

            return View("Edit", model);
        }

        // POST: SuperHeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Pull Superhero from database with ID, Update the super with collection (dictionary), save changes.
        public async Task<ActionResult> EditAsync(int id, SuperHero superHero)
        {
            
            try
            {
                _context.Update(superHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Edit", superHero);
            }
        }

        // GET: SuperHeroController/Delete/5
        public ActionResult Delete(int id)
        {

            var model = _context.SuperHeroEntries.FirstOrDefault(x => x.ID == id);
            
            return View("Delete", model);
        }
            
        // POST: SuperHeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, SuperHero superHero)
        {
            
            try
            {
                _context.Remove(superHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }                                            
            catch
            {
                return View("Delete", superHero);
            }
        }
    }
}
