﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SINGIT.Models
{
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
        [JsonProperty("track_id")]
        public long TrackId { get; set; }

        [JsonProperty("track_name")]
        public string TrackName { get; set; }

        [JsonProperty("track_name_translation_list")]
        public TrackNameTranslationList[] TrackNameTranslationList { get; set; }

        [JsonProperty("track_rating")]
        public long TrackRating { get; set; }

        [JsonProperty("commontrack_id")]
        public long CommontrackId { get; set; }

        [JsonProperty("instrumental")]
        public long Instrumental { get; set; }

        [JsonProperty("explicit")]
        public long Explicit { get; set; }

        [JsonProperty("has_lyrics")]
        public long HasLyrics { get; set; }

        [JsonProperty("has_subtitles")]
        public long HasSubtitles { get; set; }

        [JsonProperty("has_richsync")]
        public long HasRichsync { get; set; }

        [JsonProperty("num_favourite")]
        public long NumFavourite { get; set; }

        [JsonProperty("album_id")]
        public long AlbumId { get; set; }

        [JsonProperty("album_name")]
        public string AlbumName { get; set; }

        [JsonProperty("artist_id")]
        public long ArtistId { get; set; }

        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }

        [JsonProperty("track_share_url")]
        public Uri TrackShareUrl { get; set; }

        [JsonProperty("track_edit_url")]
        public Uri TrackEditUrl { get; set; }

        [JsonProperty("restricted")]
        public long Restricted { get; set; }

        [JsonProperty("updated_time")]
        public DateTimeOffset UpdatedTime { get; set; }

        [JsonProperty("primary_genres")]
        public PrimaryGenres PrimaryGenres { get; set; }
    }

    public partial class PrimaryGenres
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
        [JsonProperty("music_genre_id")]
        public long MusicGenreId { get; set; }

        [JsonProperty("music_genre_parent_id")]
        public long MusicGenreParentId { get; set; }

        [JsonProperty("music_genre_name")]
        public string MusicGenreName { get; set; }

        [JsonProperty("music_genre_name_extended")]
        public string MusicGenreNameExtended { get; set; }

        [JsonProperty("music_genre_vanity")]
        public string MusicGenreVanity { get; set; }
    }

    public partial class TrackNameTranslationList
    {
        [JsonProperty("track_name_translation")]
        public TrackNameTranslation TrackNameTranslation { get; set; }
    }

    public partial class TrackNameTranslation
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("translation")]
        public string Translation { get; set; }
    }

    public partial class Header
    {
        [JsonProperty("status_code")]
        public long StatusCode { get; set; }

        [JsonProperty("execute_time")]
        public double ExecuteTime { get; set; }

        [JsonProperty("available")]
        public long Available { get; set; }
    }

    public partial class TrackSearchObject
    {
        public static TrackSearchObject FromJson(string json) => JsonConvert.DeserializeObject<TrackSearchObject>(json, SINGIT.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TrackSearchObject self) => JsonConvert.SerializeObject(self, SINGIT.Models.Converter.Settings);
    }

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
