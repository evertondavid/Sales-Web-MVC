// Define the namespace for the models
namespace SalesWebMvc.Models.Enums
{
    /// <summary>
    /// Enum for SaleStatus.
    /// This enum represents the possible states of a sale.
    /// </summary>
    public enum SaleStatus : int
    {
        /// <summary>
        /// Sale is pending.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Sale has been billed.
        /// </summary>
        Billed = 1,

        /// <summary>
        /// Sale has been canceled.
        /// </summary>
        Canceled = 2
    }
}
