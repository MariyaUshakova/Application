using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class GatewayTimeoutException : RestException
    {
        public GatewayTimeoutException(RestResponse response) : base(response) { }
        public GatewayTimeoutException(RestResponse response, string message) : base(response, message) { }
        public GatewayTimeoutException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected GatewayTimeoutException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}