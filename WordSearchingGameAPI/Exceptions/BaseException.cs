namespace WordSearchingGameAPI.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string? message, Exception? inner) : base(message, inner) { }
    }
}
