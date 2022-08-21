using GameStore.Domain.Infrastructure;
using GameStore.Domain.Model;
using GameStore.WebUI.Areas.Admin.Models.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GameStore.WebUI.Controllers
{
    //[OutputCache(CacheProfile = "StaticUser")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            using (GameStoreDBContext context = new GameStoreDBContext())
            {
                var query = from product in context.Products
                           
                            select new ProductDTO { ProductId = product.ProductId, ProductName = product.ProductName, CategoryId = product.CategoryId, Price = product.Price, Image = product.Image, Condition = product.Condition, Discount = product.Discount, UserId = product.UserId };
                list = query.ToList();
               
            }
            return View(list);
        }
    }
}