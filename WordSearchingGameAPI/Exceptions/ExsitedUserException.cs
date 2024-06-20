namespace WordSearchingGameAPI.Exceptions
{
    public class ExsitedUserException : BaseException
    {
        public ExsitedUserException(string? message, Exception? inner) : base("Existed user, please use another account", inner) { }
    }
}
