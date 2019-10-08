using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SINGIT.Models
{
    public class ArtistModel
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

        public class ArtistCredits
        {
            [JsonProperty("artist_list")]
            public IList<string> ArtistList { get; set; }
        }

        public class SecondaryGenres
        {
            [JsonProperty("music_genre_list")]
            public IList<string> MusicGenreList { get; set; }
        }

        public class ArtistAliasList
        {
            [JsonProperty("artist_alias")]
            public string ArtistAlias { get; set; }
        }

        public class ArtistNameTranslation
        {
            [JsonProperty("language")]
            public string Language { get; set; }
            [JsonProperty("translation")]
            public string Translation { get; set; }
        }

        public class ArtistNameTranslationList
        {
            [JsonProperty("artist_name_translation")]
            public ArtistNameTranslation ArtistNameTranslation { get; set; }
        }

        public class MusicGenre
        {
            [JsonProperty("music_genre_parent_id")]
            public int MusicGenreParentID { get; set; }

            [JsonProperty("music_genre_name")]
            public string MusicGenreName { get; set; }

            [JsonProperty("music_genre_vanity")]
            public string MusicGenreVanity { get; set; }
            [JsonProperty("music_genre_id")]
            public int MusicGenreID { get; set; }
            [JsonProperty("music_genre_name_extended")]
            public string MusicGenreNameExtended { get; set; }
        }

        public class MusicGenreList
        {
            [JsonProperty("music_genre")]
            public MusicGenre MusicGenre { get; set; }
        }

        public class PrimaryGenres
        {
            [JsonProperty("music_genre_list")]
            public IList<MusicGenreList> MusicGenreList { get; set; }
        }

        public class Artist
        {
            [JsonProperty("artist_credits")]
            public ArtistCredits ArtistCredits { get; set; }

            [JsonProperty("artist_mbid")]
            public string ArtistMBID { get; set; }

            [JsonProperty("artist_name")]
            public string ArtistName { get; set; }

            [JsonProperty("secondary_genres")]
            public SecondaryGenres SecundaryGenres { get; set; }

            [JsonProperty("artist_alias_list")]
            public IList<ArtistAliasList> ArtistAliasList { get; set; }

            [JsonProperty("artist_vanity_id")]
            public string ArtistVanityID { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("artist_country")]
            public string ArtistCountry { get; set; }

            [JsonProperty("artist_comment")]
            public string ArtistComment { get; set; }

            [JsonProperty("artist_name_translation_list")]
            public IList<ArtistNameTranslationList> ArtistNameTranslationLists { get; set; }

            [JsonProperty("artist_edit_url")]
            public string ArtistEditURL { get; set; }

            [JsonProperty("artist_share_url")]
            public string ArtistShareURL { get; set; }

            [JsonProperty("artist_id")]
            public int ArtistID { get; set; }

            [JsonProperty("updated_time")]
            public string UpdateTime { get; set; }

            [JsonProperty("managed")]
            public int Managed { get; set; }

            [JsonProperty("primary_genres")]
            public PrimaryGenres PrimaryGenres { get; set; }

            [JsonProperty("artist_twitter_url")]
            public string ArtistTwitterURL { get; set; }

            [JsonProperty("artist_rating")]
            public int ArtistRating { get; set; }
        }

        public class ArtistList
        {
            [JsonProperty("artist")]
            public Artist Artist { get; set; }
        }

        public class Body
        {
            [JsonProperty("artist_list")]
            public IList<ArtistList> ArtistList { get; set; }
        }

        public class Message
        {
            [JsonProperty("header")]
            public Header Header { get; set; }
            [JsonProperty("body")]
            public Body Body { get; set; }
        }

        public class SubtitleModel
        {
            [JsonProperty("message")]
            public Message Message { get; set; }
        }
    }
}
