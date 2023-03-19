namespace Donald.BurgerClub.ViewModels
{
    public class ApiResponse<T> : ApiResponseBase
    {
        public T Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(T data, int statusCode, string errorMsg)
            : base(statusCode, errorMsg)
        {
            Data = data;
        }

        public ApiResponse(int statusCode, string errorMsg)
            : base(statusCode, errorMsg)
        {
        }
    }
}
