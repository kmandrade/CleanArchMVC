using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetallProducts();
            return View(products);
        }
        public async Task<ActionResult> Create(ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProduct(dto);
                return PartialView("Index");
            }
            ViewBag.CategoryId = new SelectList(await _categoryService.GetallCategories(), "Id", "Name"); 
            return View(dto);
        }
    }
}
