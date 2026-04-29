using System.Net;

namespace RePattern.Common.Exceptions.Custom
{
    public class NotFoundException : BaseException
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound;
        public override string DefaultMessage => "The resource you're looking for was not found!";
        public override string Code => "NOT_FOUND";

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}