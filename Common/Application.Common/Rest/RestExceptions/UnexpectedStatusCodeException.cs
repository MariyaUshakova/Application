using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class UnexpectedStatusCodeException : RestException
    {
        public UnexpectedStatusCodeException(RestResponse response) : base(response) { }
        public UnexpectedStatusCodeException(RestResponse response, string message) : base(response, message) { }
        public UnexpectedStatusCodeException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected UnexpectedStatusCodeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}