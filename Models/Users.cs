using System;

namespace ChatStudents.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Lastname { get; set; } = string.Empty;

        public string Firstname { get; set; } = string.Empty;

        public string? Surname { get; set; }

        public byte[]? Photo { get; set; }

        // Конструктор без параметров (для EF Core)
        public Users()
        {
            Lastname = string.Empty;
            Firstname = string.Empty;
        }

        // Конструктор с параметрами
        public Users(string lastname, string firstname, string? surname, byte[]? photo)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname = surname;
            Photo = photo;
        }

        public string ToFIO()
        {
            return $"{Lastname} {Firstname} {Surname}".Trim();
        }
    }
}