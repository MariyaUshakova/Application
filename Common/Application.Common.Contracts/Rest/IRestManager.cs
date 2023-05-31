using Application.Common.Types;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Common.Contracts.Rest
{
    public interface IRestManager
    {
        Task<RestResponse> Execute(
            HttpClient client,
            string resource,
            RestMethod method = RestMethod.Get,
            ICollection<KeyValuePair<string, object>> headers = null,
            ICollection<KeyValuePair<string, object>> pathParameters = null,
            ICollection<KeyValuePair<string, object>> queryParameters = null,
            object body = null);

        Task<T> Execute<T>(
            HttpClient client,
            string resource,
            RestMethod method = RestMethod.Get,
            ICollection<KeyValuePair<string, object>> headers = null,
            ICollection<KeyValuePair<string, object>> pathParameters = null,
            ICollection<KeyValuePair<string, object>> queryParameters = null,
            object body = null);
    }
}