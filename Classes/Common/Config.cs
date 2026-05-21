using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudents.Classes.Common
{
    public class Config
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public static readonly string config = "Server=student.permaviat.ru;" +
            "Trusted_Connection=False;" +
            "Database=ChatStudents;" +
            "User=your_username;" +
            "Pwd=your_password;";
    }
}