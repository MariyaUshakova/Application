using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class PreconditionFailedException : RestException
    {
        public PreconditionFailedException(RestResponse response) : base(response) { }
        public PreconditionFailedException(RestResponse response, string message) : base(response, message) { }
        public PreconditionFailedException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected PreconditionFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
