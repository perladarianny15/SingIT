using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SINGIT.Models
{
    [Table("RegisterTable")]
    public class RegisterModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Unique]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }

        [OneToMany]
        public List<FavoriteSongsModel> UserFavorites { get; set; }
       
    }
}
