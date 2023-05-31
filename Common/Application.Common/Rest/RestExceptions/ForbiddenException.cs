using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class ForbiddenException : RestException
    {
        public ForbiddenException(RestResponse response) : base(response) { }
        public ForbiddenException(RestResponse response, string message) : base(response, message) { }
        public ForbiddenException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected ForbiddenException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
