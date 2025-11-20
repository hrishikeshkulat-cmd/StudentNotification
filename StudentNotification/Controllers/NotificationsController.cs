using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentNotification.Data;
using StudentNotification.Models;

namespace StudentNotification.Controllers
{
    // Controller must be exactly "NotificationsController" (plural) so /Notifications maps here
    public class NotificationsController : Controller
    {
        private readonly AppDbContext _db;

        // Constructor: AppDbContext is injected by DI
        public NotificationsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Notifications or /Notifications/Index
        public async Task<IActionResult> Index()
        {
            // Load notifications and include the related Student (so we can display student name)
            var list = await _db.Notifications
                                .Include(n => n.Student)
                                .OrderByDescending(n => n.CreatedAt)
                                .ToListAsync();
            return View(list);
        }

        // GET: /Notifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Notifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notification notification)
        {
            if (!ModelState.IsValid)
                return View(notification);

            // Save and redirect to Index
            _db.Notifications.Add(notification);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

