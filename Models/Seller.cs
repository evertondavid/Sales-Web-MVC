using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.EmailAddress)] // Specifies the type of data (email) for the Email property in the form
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the BirthDate of the seller.
        /// </summary>
        [Display(Name = "Birth Date")] // Specifies the display name for the BirthDate property in the form
        [DataType(DataType.Date)] // Specifies the type of data (date) for the BirthDate property in the form
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] // Specifies the display format for the BirthDate property in the form
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the BaseSalary of the seller.
        /// </summary>
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "CAD$ {0:F2}")] // Specifies the display format for the BaseSalary property in the form
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
