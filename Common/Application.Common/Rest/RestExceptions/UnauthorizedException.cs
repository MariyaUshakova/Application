using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class UnauthorizedException : RestException
    {
        public UnauthorizedException(RestResponse response) : base(response) { }
        public UnauthorizedException(RestResponse response, string message) : base(response, message) { }
        public UnauthorizedException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected UnauthorizedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
