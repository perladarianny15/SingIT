using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync;
using SQLitePCL;

namespace SINGIT.Models
{
    [Table("FavoriteSongsTable")]
    public class FavoriteSongsModel
    {
        [PrimaryKey]
        public float SongID { get; set; }

        [ForeignKey(typeof(RegisterModel))] //SQLite does not support multiple primary keys
        public int UserID { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string AlbumName { get; set; }
        public string Year { get; set; }
        
    }
}
