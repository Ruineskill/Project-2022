using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.HttpClients
{
    public interface IApiHttpClient
    {
        Task<T> GetAsync<T>(string uri);
        Task<T> PostAsync<T>(string uri, T payLoad);
        Task<T> PostAsync<T,O>(string uri, O payLoad);
        Task<T> PutAsync<T>(string uri, T payLoad);
        Task<HttpStatusCode> DeleteAsync(string uri, StringContent payLoad);
        Task<HttpStatusCode> DeleteAsync(string uri);
    }
}