using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.Interfaces.ApiHttp
{
    public interface IApiHttpClient
    {
        Task<T> GetAsync<T>(string uri);
        Task<T> PostAsync<T>(string uri, T payLoad);
        Task<R> PostAsync<R, T>(string uri, T payLoad);
        Task PutAsync<T>(string uri, T payLoad);
        Task DeleteAsync(string uri);
    }
}