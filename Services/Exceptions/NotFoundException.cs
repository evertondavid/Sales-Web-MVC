// This namespace contains exception classes for the SalesWebMvc service layer.
namespace SalesWebMvc.Services.Exceptions
{
    // This class represents an exception that is thrown when an object is not found in the database.
    // It inherits from the ApplicationException class, which represents errors that occur during application execution.
    public class NotFoundException : ApplicationException
    {
        // Constructor that takes a message as a parameter.
        // This message is passed to the base class (ApplicationException) constructor.
        // <param name="message">The error message that explains the reason for the exception.</param>
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
