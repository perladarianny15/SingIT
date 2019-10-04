using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SINGIT.Models
{
   public class FavoriteSongsModel
    {
        [PrimaryKey]
        public int UserID { get; set; }
        [PrimaryKey]
        public float SongID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Year { get; set; }

    }
}
