using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class ConflictException : RestException
    {
        public ConflictException(RestResponse response) : base(response) { }
        public ConflictException(RestResponse response, string message) : base(response, message) { }
        public ConflictException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected ConflictException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
