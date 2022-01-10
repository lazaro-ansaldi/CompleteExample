using System;

namespace CompleteExample.Logic.Exceptions
{
    public class UiFatalException : UiException
    {
        public UiFatalException()
        {
        }

        public override string UserErrorMessage => "Unknown error, please retry or contact support";
    }
}
