using RestSharp;
using System;

namespace Application.Common.Rest
{
    internal record UrlSegmentUncheckedParameter : NamedParameter, IEquatable<UrlSegmentUncheckedParameter>
    {
        public UrlSegmentUncheckedParameter(string name, string value, bool encode = true)
            : base(name, value.Replace("%2F", "/").Replace("%2f", "/"), ParameterType.UrlSegment, encode)
        {
        }
    }
}