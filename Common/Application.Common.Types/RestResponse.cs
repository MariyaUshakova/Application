using System.Net;

namespace Application.Common.Types
{
    public class RestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
        public byte[] RawBytes { get; set; }
    }
}