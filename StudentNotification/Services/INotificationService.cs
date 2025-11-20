using System.Threading.Tasks;
using StudentNotification.Models;

namespace StudentNotification.Services
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(int studentId, string message);
        Task<List<Notification>> GetAllAsync();
    }
}

