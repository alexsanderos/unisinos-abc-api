using MediatR;

namespace Unisinos.Abc.Domain.Notifications
{
    public class BindStudentInCourseNotification : INotification
    {
        public Guid IdStudent { get; private set; }
        public Guid IdCourse { get; private set; }
        public string NameStudent { get; private set; }
        public string NameCourse { get; private set; }

        public BindStudentInCourseNotification(
            Guid idStudent,
            Guid idCourse,
            string nameStudent,
            string nameCourse)
        {
            IdStudent = idStudent;
            IdCourse = idCourse;
            NameStudent = nameStudent;
            NameCourse = nameCourse;
        }
    }
}