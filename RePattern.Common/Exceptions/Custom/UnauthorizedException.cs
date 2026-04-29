using System.Net;

namespace RePattern.Common.Exceptions.Custom
{
    public class UnauthorizedException : BaseException
    {
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;
        public override string DefaultMessage => "You do not have the permissions required to view this resource!";
        public override string Code => "UNAUTHORIZED";

        public UnauthorizedException(string message) : base(message) { }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
