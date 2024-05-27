// Define the namespace for the view models
namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }

        public SellerFormViewModel()
        {
            Seller = new Seller();
            Departments = new List<Department>();
        }

    }
}
