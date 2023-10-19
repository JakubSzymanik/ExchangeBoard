namespace webapi.Errors
{
    public class ApiException
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        public ApiException(int code, string message, string details)
        {
            Code = code;
            Message = message;
            Details = details;
        }
    }
}
