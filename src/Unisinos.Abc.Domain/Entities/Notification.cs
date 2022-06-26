namespace Unisinos.Abc.Domain.Entities
{
    public class Notification
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Notification(string message, bool success)
        {
            this.Message = message;
            this.Success = success;
        }
    }
}