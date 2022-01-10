using CompleteExample.Logic.Exceptions;

namespace CompleteExample.API
{
    public class ApiError
    {
        public string ErrorMessage { get; }

        public ApiError(UiException exception)
        {
            ErrorMessage = exception.UserErrorMessage;
        }
    }
}
