
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using SINGIT.Models;
using SINGIT;

namespace SINGIT.Services
{
    [Headers("Content-Type: application/json")]
    public interface ITracksByArtistsApi
    {
        [Get("/ws/1.1/track.search?q_artist={Artist}&s_track_rating=desc&apikey=aa2ae8cce618bff1f84b172ea0c75787")]
        Task<HttpResponseMessage> GetTracksByArtist(string Artist);
    }
    
}
