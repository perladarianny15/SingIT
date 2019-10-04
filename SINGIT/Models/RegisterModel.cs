using System;
using SQLite;
namespace SINGIT.Models
{
    public class RegisterModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
    }
}
