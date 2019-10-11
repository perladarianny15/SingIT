using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;


namespace SINGIT.Services
{
    [Headers("Content-Type: application/json")]
    public interface ILyricsServices
    {
        [Get("/ws/1.1/track.get?apikey=aa2ae8cce618bff1f84b172ea0c75787&callback=callback&track_id={TrackID}")]
        Task<HttpResponseMessage> GetLyrics(string TrackID);
    }
}
