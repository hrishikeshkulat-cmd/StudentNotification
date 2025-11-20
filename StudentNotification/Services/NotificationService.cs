using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudentNotification.Data;
using StudentNotification.Models;

namespace StudentNotification.Services

{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _db;

        public NotificationService(AppDbContext Appdb)
        {
            _db = Appdb;
        }

       public async Task CreateNotificationAsync(int studentId, string message)
        {
            var Notification = new Notification();
            {

               int  Studentid = studentId;
              String  Message= message;
                DateTime CreatedAt = DateTime.Now;
            };
            _db.Notifications.Add(Notification);
            await _db.SaveChangesAsync();
        }
        // Load all notifications from database
        public async Task<List<Notification>> GetAllAsync()
        {
           return await   _db.Notifications
                        .Include(n => n.Student)   // Load related Student info
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

        }


    }
}
