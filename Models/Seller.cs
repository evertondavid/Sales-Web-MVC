namespace SalesWebMvc.Models
{
    /// <summary>
    /// Class for Seller.
    /// This class represents a seller in the sales web MVC application.
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Gets or sets the Id of the seller.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the seller.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Email of the seller.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the BirthDate of the seller.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the BaseSalary of the seller.
        /// </summary>
        public double BaseSalary { get; set; }

        /// <summary>
        /// Gets or sets the Department of the seller.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Gets or sets the DepartmentId of the seller.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the Sales of the seller.
        /// </summary>
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        /// <summary>
        /// Default constructor for the Seller class.
        /// </summary>
        public Seller()
        {
        }

        /// <summary>
        /// Constructor for the Seller class.
        /// </summary>
        /// <param name="id">The Id of the seller.</param>
        /// <param name="name">The Name of the seller.</param>
        /// <param name="email">The Email of the seller.</param>
        /// <param name="birthDate">The BirthDate of the seller.</param>
        /// <param name="baseSalary">The BaseSalary of the seller.</param>
        /// <param name="department">The Department of the seller.</param>
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        /// <summary>
        /// Adds a SalesRecord to the seller.
        /// </summary>
        /// <param name="sr">The SalesRecord to be added.</param>
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        /// <summary>
        /// Removes a SalesRecord from the seller.
        /// </summary>
        /// <param name="sr">The SalesRecord to be removed.</param>
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        /// <summary>
        /// Calculates the total sales for the seller within a given date range.
        /// </summary>
        /// <param name="initial">The start date of the date range.</param>
        /// <param name="final">The end date of the date range.</param>
        /// <returns>The total sales for the seller within the date range.</returns>
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
