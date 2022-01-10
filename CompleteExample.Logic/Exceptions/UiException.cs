using System;

namespace CompleteExample.Logic.Exceptions
{
    public abstract class UiException : Exception
    {
        public abstract string UserErrorMessage { get; }
    }
}
