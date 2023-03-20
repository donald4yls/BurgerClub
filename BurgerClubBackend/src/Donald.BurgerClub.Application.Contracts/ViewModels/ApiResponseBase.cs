namespace Donald.BurgerClub.ViewModels
{
    public abstract class ApiResponseBase
    {
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccess
        {
            get
            {
                return StatusCode >= 200
                    && StatusCode < 300;
            }
        }

        public ApiResponseBase()
        {

        }

        public ApiResponseBase(int statusCode, string errorMsg)
        {
            this.StatusCode = statusCode;
            this.ErrorMessage = errorMsg;
        }
    }


}
