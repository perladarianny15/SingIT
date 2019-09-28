
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
        [Get("/ws/1.1/track.search?q_artist={q_artist}&s_track_rating=desc&apikey={Config.ApiKey}")]
        Task<HttpResponseMessage> GetTracksByArtist(string q_artist);

       
    }
}
