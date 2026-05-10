using System.Net;

namespace RePattern.Common.Exceptions.Custom
{
    public class ConfigValueNotFound : BaseException
    {
        public override int StatusCode => (int)HttpStatusCode.InternalServerError;
        public override string DefaultMessage => "Configuration value not found!";
        public override string Code => "INTERNAL_SERVER_ERROR";

        public ConfigValueNotFound(string message) : base(message) { }

        public ConfigValueNotFound(string message, Exception innerException) : base(message, innerException) { }
    }
}
