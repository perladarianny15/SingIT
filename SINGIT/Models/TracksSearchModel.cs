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

        public partial class TrackSearchObject
        {
            [JsonProperty("message")]
            public Message Message { get; set; }
        }

        public partial class Message
        {
            [JsonProperty("header")]
            public Header Header { get; set; }

            [JsonProperty("body")]
            public Body Body { get; set; }
        }

        public partial class Body
        {
            [JsonProperty("track_list")]
            public TrackList[] TrackList { get; set; }
        }

        public partial class TrackList
        {
            [JsonProperty("track")]
            public Track Track { get; set; }
        }

        public partial class Track
        {
            [JsonProperty("instrumental")]
            public long Instrumental { get; set; }

            [JsonProperty("album_coverart_350x350")]
            public string AlbumCoverart350X350 { get; set; }

            [JsonProperty("first_release_date")]
            public string FirstReleaseDate { get; set; }
            [JsonProperty("lyrics_id")]
            public long LyricsId { get; set; }

            [JsonProperty("has_lyrics")]
            public int HasLyrics { get; set; }

            [JsonProperty("track_isrc")]
            public string TrackIsrc { get; set; }

            [JsonProperty("explicit")]
            public long Explicit { get; set; }

            [JsonProperty("track_edit_url")]
            public string TrackEditUrl { get; set; }

            [JsonProperty("num_favourite")]
            public long NumFavourite { get; set; }

            [JsonProperty("album_coverart_500x500")]
            public string AlbumCoverart500X500 { get; set; }

            [JsonProperty("album_name")]
            public string AlbumName { get; set; }

            [JsonProperty("track_rating")]
            public long TrackRating { get; set; }

            [JsonProperty("track_share_url")]
            public string TrackShareUrl { get; set; }

            [JsonProperty("track_soundcloud_id")]
            public long TrackSoundcloudId { get; set; }

            [JsonProperty("artist_name")]
            public string ArtistName { get; set; }

            [JsonProperty("album_coverart_800x800")]
            public string AlbumCoverart800X800 { get; set; }

            [JsonProperty("album_coverart_100x100")]
            public string AlbumCoverart100X100 { get; set; }

            [JsonProperty("track_name_translation_list")]
            public string[] TrackNameTranslationList { get; set; }

            [JsonProperty("track_name")]
            public string TrackName { get; set; }

            [JsonProperty("restricted")]
            public long Restricted { get; set; }

            [JsonProperty("has_subtitles")]
            public long HasSubtitles { get; set; }

            [JsonProperty("updated_time")]
            public string UpdatedTime { get; set; }

            [JsonProperty("subtitle_id")]
            public long SubtitleId { get; set; }

            [JsonProperty("lyrics_id")]
            public long LyricsId { get; set; }

            [JsonProperty("track_spotify_id")]
            public string TrackSpotifyId { get; set; }

            [JsonProperty("has_lyrics")]
            public long HasLyrics { get; set; }

            [JsonProperty("artist_id")]
            public long ArtistId { get; set; }

            [JsonProperty("album_id")]
            public long AlbumId { get; set; }

            [JsonProperty("artist_mbid")]
            public string ArtistMbid { get; set; }

            [JsonProperty("secondary_genres")]
            public AryGenres SecondaryGenres { get; set; }

            [JsonProperty("commontrack_vanity_id")]
            public string CommontrackVanityId { get; set; }

            [JsonProperty("track_id")]
            public long TrackId { get; set; }

            [JsonProperty("track_xboxmusic_id")]
            public string TrackXboxmusicId { get; set; }

            [JsonProperty("primary_genres")]
            public AryGenres PrimaryGenres { get; set; }

            [JsonProperty("track_length")]
            public long TrackLength { get; set; }

            [JsonProperty("track_mbid")]
            public string TrackMbid { get; set; }

            [JsonProperty("commontrack_id")]
            public long CommontrackId { get; set; }
        }

        public partial class AryGenres
        {
            [JsonProperty("music_genre_list")]
            public MusicGenreList[] MusicGenreList { get; set; }
        }

        public partial class MusicGenreList
        {
            [JsonProperty("music_genre")]
            public MusicGenre MusicGenre { get; set; }
        }

        public partial class MusicGenre
        {
            [JsonProperty("music_genre_vanity")]
            public string MusicGenreVanity { get; set; }

            [JsonProperty("music_genre_name_extended")]
            public string MusicGenreNameExtended { get; set; }

            [JsonProperty("music_genre_name")]
            public string MusicGenreName { get; set; }

            [JsonProperty("music_genre_parent_id")]
            public long MusicGenreParentId { get; set; }

            [JsonProperty("music_genre_id")]
            public long MusicGenreId { get; set; }
        }

        public partial class Header
        {
            [JsonProperty("available")]
            public long Available { get; set; }

            [JsonProperty("status_code")]
            public long StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public long ExecuteTime { get; set; }
        }

        public partial class TrackSearchObject
        {
            public static TrackSearchObject FromJson(string json) => JsonConvert.DeserializeObject<TrackSearchObject>(json, TracksSearchModel.Converter.Settings);
        }

        //public static class Serialize
        //{
        //    public static string ToJson(this TrackSearchObject self) => JsonConvert.SerializeObject(self, TracksSearchModel.Converter.Settings);
        //}

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}
