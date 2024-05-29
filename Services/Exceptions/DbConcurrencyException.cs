// This namespace contains custom exceptions for the SalesWebMvc application.
namespace SalesWebMvc.Services.Exceptions
{
    // This class represents a custom exception for when there is a concurrency error in the database.
    // It inherits from the ApplicationException class.
    public class DbConcurrencyException : ApplicationException
    {
        // Constructor that receives a message and passes it to the base class constructor.
        // <param name="message">The message that describes the error.</param>
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
