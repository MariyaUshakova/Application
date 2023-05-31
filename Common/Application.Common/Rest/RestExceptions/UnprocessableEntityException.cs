using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class UnprocessableEntityException : RestException
    {
        public UnprocessableEntityException(RestResponse response) : base(response) { }
        public UnprocessableEntityException(RestResponse response, string message) : base(response, message) { }
        public UnprocessableEntityException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected UnprocessableEntityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
