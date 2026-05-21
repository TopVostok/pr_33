using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudents.Models
{
    public class Users
    {
        /// <summary>
        /// Код пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Фотография (хранится в виде массива байтов)
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Конструктор для заполнения объекта
        /// </summary>
        public Users(string lastname, string firstname, string surname, byte[] photo)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname = surname;
            Photo = photo;
        }

        /// <summary>
        /// Пустой конструктор (нужен для Entity Framework)
        /// </summary>
        public Users() { }

        /// <summary>
        /// Получить ФИО пользователя
        /// </summary>
        public string ToFIO()
        {
            return $"{Lastname} {Firstname} {Surname}";
        }
    }
}