using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{

    [Serializable]
    public class InternalServerErrorException : RestException
    {
        public InternalServerErrorException(RestResponse response) : base(response) { }
        public InternalServerErrorException(RestResponse response, string message) : base(response, message) { }
        public InternalServerErrorException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected InternalServerErrorException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
