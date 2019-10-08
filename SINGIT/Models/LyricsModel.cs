using System;
namespace SINGIT.Models
{
    public class LyricsModel
    {
        public Message message { get; set; }

        public class Header
        {
            public int Status_code { get; set; }
            public double Execute_time { get; set; }
        }
        public class Lyrics
        {
            public int Lyrics_id { get; set; }
            public int Explicit_ { get; set; }
            public string Lyrics_body { get; set; }
            public string Script_tracking_url { get; set; }
            public string Pixel_tracking_url { get; set; }
            public string Lyrics_copyright { get; set; }
            public DateTime Updated_time { get; set; }
        }
        public class Body
        {
            public Lyrics Lyrics { get; set; }
        }
        public class Message
        {
            public Header Header { get; set; }
            public Body Body { get; set; }
        }
    }
}
