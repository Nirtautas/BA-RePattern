namespace RePattern.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract string Message { get; }
        public abstract string Code { get; }

        protected BaseException(string message) : base(message) { }
        protected BaseException(string message, Exception innerException) : base(message, innerException) { }
        public virtual ExceptionDetails GetExceptionDetails() => new()
        {
            Message = Message,
            Code = Code
        };
    }
}
