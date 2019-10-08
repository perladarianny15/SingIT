using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SINGIT.Models
{
    public class AlbumModel
    {
        public class Header
        {
            [JsonProperty("available")]
            public int Available { get; set; }

            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public int ExecuteTime { get; set; }
        }

        public class MusicGenre
        {
            [JsonProperty("music_genre_name_extended")]
            public string MusicGenreNameExtended { get; set; }

            [JsonProperty("music_genre_vanity")]
            public string MusicGenreVanity { get; set; }

            [JsonProperty("music_genre_parent_id")]
            public int MusicGenreParentID { get; set; }

            [JsonProperty("music_genre_id")]
            public int MusicGenreID { get; set; }

            [JsonProperty("music_genre_name")]
            public string MusicGenreName { get; set; }
        }

        public class MusicGenreList
        {
            [JsonProperty("music_genre")]
            public MusicGenre MusicGenre { get; set; }
        }

        public class PrimaryGenres
        {
            [JsonProperty("music_genre_list")]
            public IList<MusicGenreList> PrimaryMusicGenreLists { get; set; }
        }

        public class SecondaryGenres
        {
            [JsonProperty("music_genre_list")]
            public IList<string> SecundaryMusicGenreList { get; set; }
        }

        public class Album
        {
            [JsonProperty("album_coverart_500x500")]
            public string AlbumCovered { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("artist_id")]
            public int ArtistID { get; set; }

            [JsonProperty("album_name")]
            public string AlbumName { get; set; }

            [JsonProperty("album_coverart_800x800")]
            public string AlbumCovertArt { get; set; }

            [JsonProperty("album_copyright")]
            public string AlbumCopyright { get; set; }

            [JsonProperty("album_coverart_350x350")]
            public string AlbumCover300x300 { get; set; }

            [JsonProperty("artist_name")]
            public string ArtistName { get; set; }

            [JsonProperty("primary_genres")]
            public PrimaryGenres primaryGenres { get; set; }

            [JsonProperty("album_id")]
            public int AlbumID { get; set; }

            [JsonProperty("album_rating")]
            public int AlbumRating { get; set; }

            [JsonProperty("album_pline")]
            public string AlbumLine { get; set; }

            [JsonProperty("album_track_count")]
            public int AlbumTrackCount { get; set; }

            [JsonProperty("album_release_type")]
            public string AlbumReleaseType { get; set; }

            [JsonProperty("album_release_date")]
            public string AlbumReleaseDate { get; set; }

            [JsonProperty("album_edit_url")]
            public string AlbumEditURL { get; set; }

            [JsonProperty("updated_time")]
            public string UpdateTime { get; set; }

            [JsonProperty("secondary_genres")]
            public SecondaryGenres SecundaryGenres { get; set; }

            [JsonProperty("album_mbid")]
            public string AlbumMBID { get; set; }

            [JsonProperty("album_vanity_id")]
            public string AlbumVanityID { get; set; }

            [JsonProperty("album_coverart_100x100")]
            public string AlbumCovertArt100 { get; set; }

            [JsonProperty("album_label")]
            public string AlbumLabel { get; set; }
        }

        public class AlbumList
        {
            [JsonProperty("album")]
            public Album Album { get; set; }
        }

        public class Body
        {
            [JsonProperty("album_list")]
            public IList<AlbumList> AlbumList { get; set; }
        }

        public class Message
        {
            [JsonProperty("Header")]
            public Header Header { get; set; }

            [JsonProperty("Body")]
            public Body Body { get; set; }
        }

        public class SubtitleModel
        {
            [JsonProperty("Message")]
            public Message Message { get; set; }
        }
    }
}
