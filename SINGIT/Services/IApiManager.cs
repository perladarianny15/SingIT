using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SINGIT.Services
{
    public interface IApiManager
    {
        Task<HttpResponseMessage> GetTracksByArtist(string q_artist);
    }

}
