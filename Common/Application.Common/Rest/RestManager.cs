using Application.Common.Contracts.Rest;
using Application.Common.Rest.RestExceptions;
using Application.Common.Types;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Common.Rest
{
    public class RestManager : IRestManager
    {
        private readonly ILogger _logger;

        private static JsonSerializerSettings SerializerSettings =
                new() { NullValueHandling = NullValueHandling.Ignore };

        private readonly int _requestTimeout = (int)TimeSpan.FromMinutes(3).TotalMilliseconds;

        public RestManager(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<Types.RestResponse> Execute(
            HttpClient client,
            string resource,
            RestMethod method = RestMethod.Get,
            ICollection<KeyValuePair<string, object>> headers = null,
            ICollection<KeyValuePair<string, object>> pathParameters = null,
            ICollection<KeyValuePair<string, object>> queryParameters = null,
            object body = null)
        {
            _logger.Verbose($"Execute HTTP-request with URI = {client.BaseAddress}, resource {resource}");

            var restClient = new RestClient(client);

            var request = new RestRequest()
            {
                Resource = resource,
                RequestFormat = DataFormat.Json,
                Method = Convert(method),
                Timeout = _requestTimeout
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value.ToString());
                }
            }

            if (pathParameters != null)
            {
                foreach (var pathParameter in pathParameters)
                {
                    var key = pathParameter.Key;
                    var value = pathParameter.Value.ToString();

                    if (value == "")
                    {
                        request.AddParameter(new UrlSegmentUncheckedParameter(key, value, true));
                    }
                    else
                    {
                        request.AddUrlSegment(key, value);
                    }
                }
            }

            if (queryParameters != null)
            {
                foreach (var queryParameter in queryParameters)
                {
                    request.AddQueryParameter(queryParameter.Key, queryParameter.Value.ToString());
                }
            }

            if (body != null)
            {
                if (body is string)
                {
                    request.AddJsonBody(body);
                }
                else
                {
                    var json = JsonConvert.SerializeObject(body, SerializerSettings);
                    request.AddStringBody(json, DataFormat.Json);
                }
            }

            var fullUri = restClient.BuildUri(request);

            _logger.Verbose($"Execute {method} request against {fullUri}");

            var response = await restClient.ExecuteAsync(request);

            if (!IsSucceeded(response))
            {
                DumpResponse(response);
            }

            AssertStatusCode(response);

            return RestExceptionRaiser.Wrap(response);
        }

        public async Task<T> Execute<T>(
            HttpClient client,
            string resource,
            RestMethod method = RestMethod.Get,
            ICollection<KeyValuePair<string, object>> headers = null,
            ICollection<KeyValuePair<string, object>> pathParameters = null,
            ICollection<KeyValuePair<string, object>> queryParameters = null,
            object body = null)
        {
            var response = await Execute(client, resource, method, headers, pathParameters, queryParameters, body);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new NoContentException(response);
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to deserialize content:{Environment.NewLine}{response.Content}");
                throw new Exception($"Error occured during result deserialization: {ex}");
            }
        }

        private bool IsSucceeded(RestSharp.RestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return false;
            }

            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }

        private void DumpResponse(RestSharp.RestResponse response)
        {
            _logger.Verbose("");
            _logger.Verbose($"Response status: {response.ResponseStatus}");
            _logger.Verbose($"Status code: {response.StatusCode}");
            _logger.Verbose($"Content:{Environment.NewLine}{response.Content}");
            _logger.Verbose("");
        }

        private void AssertStatusCode(RestSharp.RestResponse response)
        {
            var wrappedResponse = RestExceptionRaiser.Wrap(response);
            RestExceptionRaiser.RaiseException(wrappedResponse);
        }

        private Method Convert(RestMethod method)
        {
            return (Method)method;
        }

        private DataFormat Convert(RestDataFormat restDataFormat)
        {
            return (DataFormat)restDataFormat;
        }
    }
}