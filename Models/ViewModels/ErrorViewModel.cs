// Define the namespace for the view models
namespace SalesWebMvc.Models.ViewModels
{
    /// <summary>
    /// Class for ErrorViewModel.
    /// This class represents the model for the error view.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the RequestId.
        /// This is the unique identifier for the HTTP request that caused the error.
        /// </summary>
        public string? RequestId { get; set; }
        /// <summary>
        /// Gets or sets the Message.
        /// This is the error message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets a value indicating whether to show the RequestId.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
