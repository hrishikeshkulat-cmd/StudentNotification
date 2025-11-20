using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentNotification.Data;    
using StudentNotification.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudentNotification.Controllers
{
    public class StudentsController: Controller
    {
        private readonly AppDbContext _Db;

        public StudentsController(AppDbContext appDb)
        {
            _Db = appDb;
        }

        //List of students
        public async Task<IActionResult> Index()
        {
            var student = await _Db.Students
                            .AsNoTracking()
                            .OrderBy(s => s.Name)
                            .ToListAsync();
            return View(student);
        }
        //taking student details by searching 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();//400 client error

            var student = _Db.Students
                         .AsNoTracking()
                         .FirstOrDefault(s => s.Id == id);

            return View(student);

        }

        //creating a empty Create page view
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // prevents CSRF attacks
        public async Task<IActionResult> Create([Bind("Name", "Email")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            _Db.Students.Add(student);
            await _Db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        //edit student details
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            var student = await _Db.Students.FindAsync(id.Value);
            if (student == null) return BadRequest();
            return View(student); // pass Student to Edit view

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Email")] Student student)
        {
            if (id != student.Id)
            {
                // If route id and form Id mismatch -> bad request
                return BadRequest();
            }

            if (!ModelState.IsValid)
            { return View(student); }

            try
            {
                _Db.Update(student);
                await _Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Concurrency exception occurs if the record was changed/deleted by someone else.
                // Check if record still exists:
                var exists = await _Db.Students.AnyAsync(e => e.Id == student.Id);
                if (!exists) return NotFound();
                // If it exists but concurrency problem persists, rethrow so system returns 500.
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Delete(int? id) 
        {
            if (id==null) return BadRequest();

            var student= await _Db.Students
                   .AsNoTracking()
                   .FirstOrDefaultAsync(s => s.Id == id.Value);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")] // maps to form action "Delete" even though method name differs
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find entity by primary key
            var student = await _Db.Students.FindAsync(id);
            if (student == null) // already deleted
                return NotFound();

            _Db.Students.Remove(student); // mark for deletion
            await _Db.SaveChangesAsync(); // persist

            return RedirectToAction(nameof(Index));
        }


    } 
} 