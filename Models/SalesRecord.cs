using SalesWebMvc.Models.Enums;

// Define the namespace for the models
namespace SalesWebMvc.Models
{
    /// <summary>
    /// Class for SalesRecord.
    /// This class represents a record of a sale.
    /// </summary>
    public class SalesRecord
    {
        // Properties of the SalesRecord class
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller? Seller { get; set; }

        /// <summary>
        /// Default constructor for the SalesRecord class.
        /// </summary>
        public SalesRecord()
        {
        }

        /// <summary>
        /// Constructor for the SalesRecord class.
        /// </summary>
        /// <param name="id">The ID of the sales record.</param>
        /// <param name="date">The date of the sale.</param>
        /// <param name="amount">The amount of the sale.</param>
        /// <param name="status">The status of the sale.</param>
        /// <param name="seller">The seller who made the sale.</param>
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
