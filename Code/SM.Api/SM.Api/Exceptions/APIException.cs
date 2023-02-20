namespace SM.Api.Exceptions
{
    [Serializable]
    public class APIException : Exception
    {
        public APIException() { }
        public APIException(string message) : base(message) { }
    }
}
