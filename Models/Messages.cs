using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudents.Models
{
    public class Messages
    {
        /// <summary>
        /// Код сообщения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        public int UserFrom { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        public int UserTo { get; set; }

        /// <summary>
        /// 
        /// Текст сообщения
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Конструктор для сообщения
        /// </summary>
        public Messages(int userFrom, int userTo, string message)
        {
            UserFrom = userFrom;
            UserTo = userTo;
            Message = message;
        }

        /// <summary>
        /// Пустой конструктор для Entity Framework
        /// </summary>
        public Messages() { }
    }
}