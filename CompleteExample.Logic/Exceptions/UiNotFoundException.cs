namespace CompleteExample.Logic.Exceptions
{
    public class UiNotFoundException : UiException
    {
        public UiNotFoundException(string resourceName) => ResourceName = resourceName;
        public string ResourceName { get; }

        public override string UserErrorMessage => $"Resource not found: {ResourceName}";
    }
}
