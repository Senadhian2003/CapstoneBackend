namespace CoffeeStoreManagementApp.Exceptions
{
    public class ElementNotFoundException : Exception
    {

        string message;

        public ElementNotFoundException(string element)
        {
            message = $"The {element} does not exist.";
        }

        public override string Message => message;

    }
}
