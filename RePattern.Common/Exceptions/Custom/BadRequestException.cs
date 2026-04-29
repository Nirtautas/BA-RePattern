using System.Net;

namespace RePattern.Common.Exceptions.Custom
{
    public class BadRequestException : BaseException
    {
        public override int StatusCode => (int)HttpStatusCode.BadRequest;
        public override string DefaultMessage => "The request violates business rules in some way or is malformed!";
        public override string Code => "BAD_REQUEST";

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
