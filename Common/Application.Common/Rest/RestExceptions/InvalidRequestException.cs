using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class InvalidRequestException : RestException
    {
        public InvalidRequestException(RestResponse response) : base(response) { }
        public InvalidRequestException(RestResponse response, string message) : base(response, message) { }
        public InvalidRequestException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected InvalidRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
