using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace SINGIT.Services
{
    [Headers("Content-Type: application/json")]

    public interface IAlbumService
    {
        [Get("ws/1.1/artist.albums.get?apikey={Config.ApiKey}&format=JSON&callback=callback&artist_id=2")]

        Task<HttpResponseMessage> GetAlbumByName(string Artist);
    }
}
