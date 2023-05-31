using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class RestException : Exception
    {
        public RestResponse Response { get; }

        public RestException(RestResponse response)
        {
            Response = response;
        }

        public RestException(RestResponse response, string message) : base(message)
        {
            Response = response;
        }

        public RestException(RestResponse response, string message, Exception inner) : base(message, inner)
        {
            Response = response;
        }
        protected RestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
