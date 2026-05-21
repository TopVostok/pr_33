using System;

namespace ChatStudents.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public int UserFrom { get; set; }

        public int UserTo { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime SentAt { get; set; }

        // Конструктор без параметров (для EF Core)
        public Messages()
        {
            Message = string.Empty;
            SentAt = DateTime.Now;
        }

        // Конструктор с параметрами
        public Messages(int userFrom, int userTo, string message)
        {
            UserFrom = userFrom;
            UserTo = userTo;
            Message = message;
            SentAt = DateTime.Now;
        }
    }
}