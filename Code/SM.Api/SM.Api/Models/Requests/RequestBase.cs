namespace SM.Api.Models.Requests
{
    public class RequestBase
    {
        public string FunctionID { get; set; } = string.Empty;
        public string RequestStatus { get; set; } = string.Empty;
        public Guid UserID { get; set; }
    }
}
