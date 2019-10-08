using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SINGIT.Models
{
    public class SubtitleModel
    {
        //[JsonProperty("available")]
        //public Message Message { get; set; }

        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public int ExecuteTime { get; set; }
        }

        public class Subtitle
        {
            [JsonProperty("subtitle_body")]
            public string SubtitleBody { get; set; }

            [JsonProperty("publisher_list")]
            public IList<string> PublisherList { get; set; }

            [JsonProperty("subtitle_language")]
            public string SubtitleLanguage { get; set; }

            [JsonProperty("subtitle_language_description")]
            public string SubtitleLanguageDescription { get; set; }

            [JsonProperty("subtitle_id")]
            public int SubtitleId { get; set; }

            [JsonProperty("pixel_tracking_url")]
            public string PixelTrackingUrl { get; set; }

            [JsonProperty("html_tracking_url")]
            public string HtmlTrackingUrl { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("lyrics_copyright")]
            public string LyricsCopyright { get; set; }

            [JsonProperty("script_tracking_url")]
            public string ScriptTrackingUrl { get; set; }

            [JsonProperty("subtitle_length")]
            public int SubtitleLength { get; set; }

            [JsonProperty("updated_time")]
            public string UpdatedTime { get; set; }

            [JsonProperty("writer_list")]
            public IList<string> WriterList { get; set; }
        }

        public class Body
        {
            [JsonProperty("subtitle")]
            public Subtitle Subtitle { get; set; }
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
