using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SINGIT.Models
{
    public class TracksSearchModel
    {
        public Message message { get; set; }


        public class Header
        {
            public int status_code { get; set; }
            public double execute_time { get; set; }
            public int available { get; set; }
        }

        public class PrimaryGenres
        {
            public IList<object> music_genre_list { get; set; }
        }

        public class Track
        {
            public int track_id { get; set; }
            public string track_name { get; set; }
            public IList<object> track_name_translation_list { get; set; }
            public int track_rating { get; set; }
            public int commontrack_id { get; set; }
            public int instrumental { get; set; }
            public int explicitid { get; set; }
            public int has_lyrics { get; set; }
            public int has_subtitles { get; set; }
            public int has_richsync { get; set; }
            public int num_favourite { get; set; }
            public int album_id { get; set; }
            public string album_name { get; set; }
            public int artist_id { get; set; }
            public string artist_name { get; set; }
            public string track_share_url { get; set; }
            public string track_edit_url { get; set; }
            public int restricted { get; set; }
            public DateTime updated_time { get; set; }
            public PrimaryGenres primary_genres { get; set; }
        }
        public class TrackList
        {
            public Track track { get; set; }
        }

        public class Body
        {
            public IList<TrackList> track_list { get; set; }
        }

        public class Message
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }
    }
}
