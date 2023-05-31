using Application.Common.Rest.RestExceptions;
using System.Net;
using System.Net.Http;

namespace Application.Common.Rest
{
    public static class RestExceptionRaiser
    {
        public static Types.RestResponse Wrap(RestSharp.RestResponse response)
        {
            return new Types.RestResponse()
            {
                StatusCode = response.StatusCode,
                Content = response.Content,
                RawBytes = response.RawBytes
            };
        }

        public static Types.RestResponse Wrap(HttpResponseMessage message)
        {
            return new Types.RestResponse()
            {
                StatusCode = message.StatusCode,
                Content = message.Content.ReadAsStringAsync().Result
            };
        }

        public static void RaiseException(Types.RestResponse wrappedResponse)
        {
            if (((int)wrappedResponse.StatusCode) == 422)
            {
                throw new UnprocessableEntityException(wrappedResponse);
            }

            switch (wrappedResponse.StatusCode)
            {
                case 0:
                    throw new InvalidRequestException(wrappedResponse);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(wrappedResponse);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(wrappedResponse);
                case HttpStatusCode.Conflict:
                    throw new ConflictException(wrappedResponse);
                case HttpStatusCode.InternalServerError:
                    throw new InternalServerErrorException(wrappedResponse);
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException(wrappedResponse);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(wrappedResponse);
                case HttpStatusCode.UnsupportedMediaType:
                    throw new UnsupportedMediaTypeException(wrappedResponse);
                case HttpStatusCode.MethodNotAllowed:
                    throw new MethodNotAllowedException(wrappedResponse);
                case HttpStatusCode.Gone:
                    throw new GoneException(wrappedResponse);
                case HttpStatusCode.PreconditionFailed:
                    throw new PreconditionFailedException(wrappedResponse);
                case HttpStatusCode.ServiceUnavailable:
                    throw new ServiceUnavailableException(wrappedResponse);
                case HttpStatusCode.BadGateway:
                    throw new BadGatewayException(wrappedResponse);
                case HttpStatusCode.RequestTimeout:
                    throw new RequestTimeoutException(wrappedResponse);
                case HttpStatusCode.GatewayTimeout:
                    throw new GatewayTimeoutException(wrappedResponse);
            }
        }
    }
}