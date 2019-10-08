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
        public class Header
        {
            [JsonProperty("status_code")]
            public int Status_code { get; set; }

            [JsonProperty("execute_time")]
            public double Execute_time { get; set; }

            [JsonProperty("available")]
            public int Available { get; set; }
        }

        public class PrimaryGenres
        {
            [JsonProperty("available")]
            public IList<object> MusicGenreList { get; set; }
        }

        public class Track
        {
            [JsonProperty("track_id")]
            public int TrackId { get; set; }

            [JsonProperty("track_name")]
            public string TrackName { get; set; }

            [JsonProperty("track_name_translation_list")]
            public IList<object> TracknameTranslationList { get; set; }

            [JsonProperty("track_rating")]
            public int TrackRating { get; set; }

            [JsonProperty("commontrack_id")]
            public int CommontrackId { get; set; }

            [JsonProperty("instrumental")]
            public int Instrumental { get; set; }

            [JsonProperty("explicitid")]
            public int Explicitid { get; set; }

            [JsonProperty("has_lyrics")]
            public int HasLyrics { get; set; }

            [JsonProperty("has_subtitles")]
            public int HasSubtitles { get; set; }

            [JsonProperty("has_richsync")]
            public int HasRichsync { get; set; }

            [JsonProperty("num_favourite")]
            public int NumFavourite { get; set; }

            [JsonProperty("album_id")]
            public int AlbumId { get; set; }

            [JsonProperty("album_name")]
            public string AlbumName { get; set; }

            [JsonProperty("artist_id")]
            public int ArtistId { get; set; }

            [JsonProperty("artist_name")]
            public string ArtistName { get; set; }

            [JsonProperty("track_share_url")]
            public string TrackShareUrl { get; set; }

            [JsonProperty("track_edit_url")]
            public string TrackEditUrl { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("updated_time")]
            public DateTime UpdatedTime { get; set; }

            [JsonProperty("primary_genres")]
            public PrimaryGenres PrimaryGenres { get; set; }
        }
        public class TrackList
        {
            [JsonProperty("track")]
            public Track Track { get; set; }
        }

        public class Body
        {
            [JsonProperty("track_list")]
            public IList<TrackList> TrackList { get; set; }
        }

        public class Message
        {
            [JsonProperty("header")]
            public Header Header { get; set; }

            [JsonProperty("body")]
            public Body Body { get; set; }
        }
    }
}
