namespace Unisinos.Abc.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Key { get; private set; }
        public ICollection<Student> Students { get; set; }

        public Course(Guid id, string name, string key)
        {
            Id = id;
            Name = name;
            Key = key;
        }
    }
}