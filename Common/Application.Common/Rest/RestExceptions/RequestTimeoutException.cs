using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class RequestTimeoutException : RestException
    {
        public RequestTimeoutException(RestResponse response) : base(response) { }
        public RequestTimeoutException(RestResponse response, string message) : base(response, message) { }
        public RequestTimeoutException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected RequestTimeoutException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}