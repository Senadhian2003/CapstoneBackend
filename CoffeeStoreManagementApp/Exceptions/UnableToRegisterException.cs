namespace CoffeeStoreManagementApp.Exceptions
{
    public class UnableToRegisterException : Exception
    {

        string message;
        public UnableToRegisterException(string data)
        {

            message = data;
        }

        public override string Message => message;

    }
}
