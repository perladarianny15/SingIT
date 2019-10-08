using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace SINGIT.Services
{
    [Headers("Content-Type: application/json")]

    public interface IArtistServices
    {
        [Get("ws/1.1/artist.search?apikey=aa2ae8cce618bff1f84b172ea0c75787&format=json&callback=callback&q_artist={Artist}")]

        Task<HttpResponseMessage> GetArtistByName(string Artist);
    }
}
