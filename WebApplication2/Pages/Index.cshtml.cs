using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }
         
        public void OnGet()
        {
            Products = new ProductService().GetProducts(); 
        }
    }
}