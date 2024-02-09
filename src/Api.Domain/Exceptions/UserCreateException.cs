namespace Api.Domain.Exceptions
{
    public class UserCreateException : Exception
    {
        public UserCreateException() : base() { }

        public UserCreateException(string message) : base(message) { }

        public UserCreateException(string message, Exception innerException) : base(message, innerException) { }

    }
}