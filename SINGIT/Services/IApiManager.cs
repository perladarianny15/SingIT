using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SINGIT.Services
{
    public interface IApiManager
    {
        Task<HttpResponseMessage> GetTracksByArtist(string Artist);
        Task<HttpResponseMessage> GetArtist(string ArtistName);
        Task<HttpResponseMessage> GetAlbumByName(string Album);
        Task<HttpResponseMessage> GetLyrics(string TrackID);
    }

}
