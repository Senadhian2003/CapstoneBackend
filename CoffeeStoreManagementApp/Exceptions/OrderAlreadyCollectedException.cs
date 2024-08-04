namespace CoffeeStoreManagementApp.Exceptions
{
    public class OrderAlreadyCollectedException : Exception
    {
        string message;

        public OrderAlreadyCollectedException()
        {
            message = "The order has already been collected by the user.";
        }

        public override string Message => message;


    }
}
