using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.HttpClients
{
    public interface IApiHttpClient
    {
        Task<T> GetAsync<T>(string uri);
        Task<HttpStatusCode> PostAsync<T>(string uri, T payLoad);
        Task<R> PostAsync<R,T>(string uri, T payLoad);
        Task<HttpStatusCode> PutAsync<T>(string uri, T payLoad);
        Task<HttpStatusCode> DeleteAsync(string uri);
    }
}