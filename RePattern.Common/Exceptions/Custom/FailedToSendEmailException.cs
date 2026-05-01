using System.Net;

namespace RePattern.Common.Exceptions.Custom
{
    public class FailedToSendEmailException : BaseException
    {
        public override int StatusCode => (int)HttpStatusCode.BadGateway;
        public override string DefaultMessage => "Failed to send email!";
        public override string Code => "BAD_GATEWAY";

        public FailedToSendEmailException(string message) : base(message) { }

        public FailedToSendEmailException(string message, Exception innerException) : base(message, innerException) { }
    }
}
