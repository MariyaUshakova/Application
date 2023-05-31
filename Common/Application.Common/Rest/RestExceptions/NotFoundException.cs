using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class NotFoundException : RestException
    {
        public NotFoundException(RestResponse response) : base(response) { }
        public NotFoundException(RestResponse response, string message) : base(response, message) { }
        public NotFoundException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected NotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
