using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class UnsupportedMediaTypeException : RestException
    {
        public UnsupportedMediaTypeException(RestResponse response) : base(response) { }
        public UnsupportedMediaTypeException(RestResponse response, string message) : base(response, message) { }
        public UnsupportedMediaTypeException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected UnsupportedMediaTypeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
