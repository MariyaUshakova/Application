using Application.Common.Contracts.Rest;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Net.Http;

namespace Application.Controller.IntegrationTests.Api
{
    public abstract class BaseApi
    {
        protected readonly ILogger _logger;
        protected readonly HttpClient _client;
        protected readonly IRestManager _restManager;

        public int Version { get; }

        public abstract string ControllerName { get; }

        public BaseApi(ILogger logger, HttpClient client, IRestManager restManager, int version)
        {
            _logger = logger;
            _client = client;
            _restManager = restManager;

            Version = version;
        }

        protected string WrapResourcePath(string resourceRelationalPath)
        {
            var wrappedPath = string.Concat(ControllerName, "/", resourceRelationalPath.TrimStart('/'));

            _logger.Verbose($"Wrapped path: {wrappedPath}");

            return wrappedPath;
        }
    }
}