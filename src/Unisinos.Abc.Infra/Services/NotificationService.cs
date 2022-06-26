using System.Collections.Generic;
using Unisinos.Abc.Domain.Entities;
using Unisinos.Abc.Domain.Interfaces;
using Unisinos.Abc.Infra.Dto.Infra;

namespace Unisinos.Abc.Infra.Services
{
    public class NotificationService : INotificationService
    {
        private IList<Notification> _notification;

        public NotificationService()
        {
            this._notification = new List<Notification>();
        }

        public void AddNotification(string message, bool success)
        {
            this._notification.Add(new Notification(message, success));
        }

        public IList<Notification> GetNotification()
        {
            return this._notification;
        }

        public bool HasNotificationError()
        {
            return this._notification.Any(message => message.Success == false);
        }

    }
}