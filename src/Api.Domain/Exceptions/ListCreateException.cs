namespace Api.Domain.Exceptions
{
    public class ListCreateException :  Exception
    {
         public ListCreateException() : base() { }

        public ListCreateException(string message) : base(message) { }

        public ListCreateException(string message, Exception innerException) : base(message, innerException) { }
    }
}