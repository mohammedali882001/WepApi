using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAp1.Models;
using WepAp1.ViewModels;

namespace WepAp1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Context context;

        public CategoryController(Context context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<dynamic> Get(int id)
        {
            Category category = context.Categories.Include(c=>c.Products).FirstOrDefault(c=>c.Id==id);
            CategoryViewModel categoryVM = new CategoryViewModel();
            if (category != null)
            {
                categoryVM.Id = category.Id;
                categoryVM.Name = category.Name;
                if (category.Products != null)
                {
                    foreach (Product product in category.Products)
                    {
                        categoryVM.ProductsName.Add(product.Name);
                    }
                }

                MyResponse SuccessResponse= new MyResponse();
                SuccessResponse.IsPassed = true;
                SuccessResponse.Message = categoryVM;
                return SuccessResponse;
            }
            else
            {
                MyResponse ErrorResponse= new MyResponse();
                ErrorResponse.IsPassed = false;
                ErrorResponse.Message = "This Category Not Found";
                return ErrorResponse;
            }
        }
    }
}
