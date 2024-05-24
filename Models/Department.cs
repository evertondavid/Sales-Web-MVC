namespace SalesWebMvc.Models
{
    /// <summary>
    /// Class for Department.
    /// This class represents a department in the sales web MVC application.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Gets or sets the Id of the department.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the department.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Sellers in the department.
        /// </summary>
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        /// <summary>
        /// Default constructor for the Department class.
        /// </summary>
        public Department()
        {
        }

        /// <summary>
        /// Constructor for the Department class.
        /// </summary>
        /// <param name="id">The Id of the department.</param>
        /// <param name="name">The Name of the department.</param>
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Adds a Seller to the department.
        /// </summary>
        /// <param name="seller">The Seller to be added.</param>
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        /// <summary>
        /// Calculates the total sales for the department within a given date range.
        /// </summary>
        /// <param name="initial">The start date of the date range.</param>
        /// <param name="final">The end date of the date range.</param>
        /// <returns>The total sales for the department within the date range.</returns>
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
