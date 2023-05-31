﻿using Application.Common.Types;
using System;

namespace Application.Common.Rest.RestExceptions
{
    [Serializable]
    public class ServiceUnavailableException : RestException
    {
        public ServiceUnavailableException(RestResponse response) : base(response) { }
        public ServiceUnavailableException(RestResponse response, string message) : base(response, message) { }
        public ServiceUnavailableException(RestResponse response, string message, Exception inner) : base(response, message, inner) { }
        protected ServiceUnavailableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}