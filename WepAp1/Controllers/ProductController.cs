using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingMVC.Repo;
using WepAp1.Models;
using WepAp1.ViewModels;

namespace WepAp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = productRepo.GetAll();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productVM)
        {
            if (productVM != null) 
            {
                Product product=new Product() {
                    Name=productVM.Name ,
                    Description=productVM.Description  ,
                    Price=productVM.Price ,
                    Quantity=productVM.Quantity ,
                };
            }
        }
    }
}
