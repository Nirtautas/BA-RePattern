namespace RePattern.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract int StatusCode { get; }
        public abstract string DefaultMessage { get; }
        public abstract string Code { get; }

        public string FinalMessage =>
            string.IsNullOrWhiteSpace(base.Message)
               ? DefaultMessage
               : base.Message;

        protected BaseException(string message) : base(message) { }
        protected BaseException(string message, Exception innerException) : base(message, innerException) { }

        public virtual ExceptionDetails GetExceptionDetails() => new()
        {
            Message = Message,
            Code = Code
        };
    }
}
