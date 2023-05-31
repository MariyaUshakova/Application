using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class BadGatewayException : RestException
    {
        public BadGatewayException(RestResponse response) : base(response) { }
        public BadGatewayException(RestResponse response, string message) : base(response, message) { }
        public BadGatewayException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected BadGatewayException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}