namespace CoffeeStoreManagementApp.Exceptions
{
    public class EmptyListException : Exception
    {

        string message;
        public EmptyListException(string element)
        {
            message = $"The {element} List is empty";
        }

        public override string Message => message;
    }
}
