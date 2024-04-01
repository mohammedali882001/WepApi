using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult GetAll()
        {
            List<Product> products = productRepo.GetAll();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GeByIdt(int id)
        {
            Product product = productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }else
            {
                return Ok(product);
            }
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

                productRepo.Insert(product);
                productRepo.Save();

                return Ok(product);
            }

            return BadRequest("Error");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                productRepo.Delete(id);
                productRepo.Save();
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult Update(int id ,  ProductViewModel UpdatedProduct)
        {
            Product product = productRepo.GetById (id);
            if(product == null)
            {
                return BadRequest("Error");
            }else
            {
                product.Name = UpdatedProduct.Name;
                product.Description = UpdatedProduct.Description;
                product.Price = UpdatedProduct.Price;
                product.Quantity = UpdatedProduct.Quantity;
                productRepo.Update(product);
                productRepo.Save();

                return NoContent();
            }
        }

    }
}
