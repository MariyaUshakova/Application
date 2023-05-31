using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class BadRequestException : RestException
    {
        public BadRequestException(RestResponse response) : base(response) { }
        public BadRequestException(RestResponse response, string message) : base(response, message) { }
        public BadRequestException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected BadRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
