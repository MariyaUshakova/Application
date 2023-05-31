using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class NoContentException : RestException
    {
        public NoContentException(RestResponse response) : base(response) { }
        public NoContentException(RestResponse response, string message) : base(response, message) { }
        public NoContentException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected NoContentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
