namespace CoffeeStoreManagementApp.Exceptions
{
    public class UnauthorizedUserException : Exception
    {

        string message;

        public UnauthorizedUserException(string data)
        {
            message = data;
        }

        public override string Message => message;


    }
}
