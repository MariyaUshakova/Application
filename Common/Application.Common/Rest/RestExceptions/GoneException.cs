using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class GoneException : RestException
    {
        public GoneException(RestResponse response) : base(response) { }
        public GoneException(RestResponse response, string message) : base(response, message) { }
        public GoneException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected GoneException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
