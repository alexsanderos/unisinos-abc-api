using Unisinos.Abc.Domain.Entities;

namespace Unisinos.Abc.Domain.Interfaces
{
    public interface INotificationService
    {
        void AddNotification(string message, bool success);
        IList<Notification> GetNotification();
        bool HasNotificationError();
    }
}