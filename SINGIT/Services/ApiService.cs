using System;
using System.Net.Http;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace SINGIT.Services
{
    public class ApiService<T> : IApiService<T>
    {
        Func<HttpMessageHandler, T> CreateClient;
        public ApiService(string ApiBaseAddress)
        {
            CreateClient = messageHandler =>
            {
                var Client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(ApiBaseAddress)
                };

                return RestService.For<T>(Client);
            };
        }

        private T Background
        {
            get
            {
                return new Lazy<T>(() => CreateClient(
                    new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background))).Value;
            }
        }

        private T UserInitiated
        {
            get
            {
                return new Lazy<T>(() => CreateClient(
              new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated))).Value;
            }
        }

        private T Speculative
        {
            get
            {
                return new Lazy<T>(() =>CreateClient(
              new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative))).Value;
            }
        }

        public T GetApi(Priority priority)
        {
            switch (priority)
            {
                case Priority.Background:
                    return Background;
                case Priority.UserInitiated:
                    return UserInitiated;
                case Priority.Speculative:
                    return Speculative;
                default:
                    return UserInitiated;
            }
        }

    }
}
