using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingMVC.Repo;


namespace WepAp1.Models
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(Context _context) : base(_context)
        {
        }
    }
}
