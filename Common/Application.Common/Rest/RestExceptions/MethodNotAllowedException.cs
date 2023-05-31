using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class MethodNotAllowedException : RestException
    {
        public MethodNotAllowedException(RestResponse response) : base(response) { }
        public MethodNotAllowedException(RestResponse response, string message) : base(response, message) { }
        public MethodNotAllowedException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected MethodNotAllowedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
