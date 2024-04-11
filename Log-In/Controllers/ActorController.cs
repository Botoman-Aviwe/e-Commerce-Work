using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Log_In.Data;
using Log_In.Models;
using Log_In.Data.Services;

namespace Log_In.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _service;

        public ActorController(IActorService service)
        {
            _service = service;
        }

        // GET: Actor
        public async Task<IActionResult> Index()
        {
            // return View(await service.Actor.ToListAsync());
            var data = await _service.GetAll();
            return View(data);
        }

        // GET: Actor/Details/5
        public async  Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
       
        }

        // GET: Actor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
            
        }

        // POST: Actor/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                //_service.Add(actor);
                //_service.SaveChangesAsync();
                return View(actor);

            }
            _service.Update(id,actor);
            return RedirectToAction("Index");
        }

        // GET: Actor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //Checking if the actor is availabl if not not found to desplay
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);

        }

        // POST: Actor/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,Action("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //Checking if the actor is availabl if not not found to desplay
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
           
            return RedirectToAction("Index");
        }

        // GET: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        // Withe the async added here I am testing this code
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                //_service.Add(actor);
                //_service.SaveChangesAsync();
                return View(actor);
              
            }
            await _service.Add(actor);
            return RedirectToAction("Index");
        }

        //    // GET: Actor/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var actor = await _context.Actor.FindAsync(id);
        //        if (actor == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(actor);
        //    }

        //    // POST: Actor/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
        //    {
        //        if (id != actor.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(actor);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!ActorExists(actor.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(actor);
        //    }

        //    // GET: Actor/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var actor = await _context.Actor
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (actor == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(actor);
        //    }

        //    // POST: Actor/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var actor = await _context.Actor.FindAsync(id);
        //        if (actor != null)
        //        {
        //            _context.Actor.Remove(actor);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool ActorExists(int id)
        //    {
        //        return _context.Actor.Any(e => e.Id == id);
        //    }
    }
}
