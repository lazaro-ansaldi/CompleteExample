namespace CompleteExample.Logic.Exceptions
{
    public class UiValidationException : UiException
    {
        public UiValidationException(string errorMessage) => ErrorMessage = errorMessage;

        public string ErrorMessage { get; }

        public override string UserErrorMessage => $"Validation Error: {ErrorMessage}";
    }
}
