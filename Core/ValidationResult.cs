namespace AuctionApplication.Core
{
    public class ValidationResult
    {
        public Boolean IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResult() 
        {
            IsSuccess = true;
        }

        public void SetError(string errorMessage) 
        {
            ErrorMessage = errorMessage;
            IsSuccess = false;
        }
    }
}
