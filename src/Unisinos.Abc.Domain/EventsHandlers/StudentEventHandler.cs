using MediatR;
using Unisinos.Abc.Domain.Interfaces;
using Unisinos.Abc.Domain.Notifications;

namespace Unisinos.Abc.Domain.EventsHandlers
{
    public class StudentEventHandler :
        INotificationHandler<StudentCreatedNotification>,
        INotificationHandler<BindStudentInCourseNotification>
    {
        private readonly INotificationService _notification;
        public StudentEventHandler(INotificationService notificationService)
        {
            _notification = notificationService;
        }
        public Task Handle(StudentCreatedNotification notification, CancellationToken cancellationToken)
        {
            _notification.AddNotification($"Estudante {notification.Name} criado com sucesso!", true);

            return Task.CompletedTask;
        }

        public Task Handle(BindStudentInCourseNotification notification, CancellationToken cancellationToken)
        {
            _notification.AddNotification($"Estudante {notification.NameStudent} vinculado ao curso {notification.NameCourse} com sucesso!", true);

            return Task.CompletedTask;
        }
    }
}