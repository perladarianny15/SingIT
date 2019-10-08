using System;
using System.Collections.Generic;
using static SINGIT.Models.TrackInformationModel;

namespace SINGIT.Models
{
    public class TrackInformationModel
    {
        public class Header
        {
            public int status_code { get; set; }
            public int execute_time { get; set; }
        }

        public class MusicGenre
        {
            public string music_genre_vanity { get; set; }
            public string music_genre_name_extended { get; set; }
            public int music_genre_parent_id { get; set; }
            public string music_genre_name { get; set; }
            public int music_genre_id { get; set; }
        }

        public class MusicGenreList
        {
            public MusicGenre music_genre { get; set; }
        }

        public class SecondaryGenres
        {
            public IList<MusicGenreList> music_genre_list { get; set; }
        }


        public class PrimaryGenres
        {
            public IList<MusicGenreList> music_genre_list { get; set; }
        }

        public class Track
        {
            public int instrumental { get; set; }
            public string album_coverart_350x350 { get; set; }
            public string first_release_date { get; set; }
            public string track_isrc { get; set; }
            public int explicite { get; set; }
            public string track_edit_url { get; set; }
            public int num_favourite { get; set; }
            public string album_coverart_500x500 { get; set; }
            public string album_name { get; set; }
            public int track_rating { get; set; }
            public string track_share_url { get; set; }
            public int track_soundcloud_id { get; set; }
            public string artist_name { get; set; }
            public string album_coverart_800x800 { get; set; }
            public string album_coverart_100x100 { get; set; }
            public IList<string> track_name_translation_list { get; set; }
            public string track_name { get; set; }
            public int restricted { get; set; }
            public int has_subtitles { get; set; }
            public string updated_time { get; set; }
            public int subtitle_id { get; set; }
            public int lyrics_id { get; set; }
            public string track_spotify_id { get; set; }
            public int has_lyrics { get; set; }
            public int artist_id { get; set; }
            public int album_id { get; set; }
            public string artist_mbid { get; set; }
            public SecondaryGenres secondary_genres { get; set; }
            public string commontrack_vanity_id { get; set; }
            public int track_id { get; set; }
            public string track_xboxmusic_id { get; set; }
            public PrimaryGenres primary_genres { get; set; }
            public int track_length { get; set; }
            public string track_mbid { get; set; }
            public int commontrack_id { get; set; }
        }

        public class Body
        {
            public Track track { get; set; }
        }

        public class Message
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }

        public class SubtitleModel
        {
            public Message message { get; set; }
        }
       
    }
}
