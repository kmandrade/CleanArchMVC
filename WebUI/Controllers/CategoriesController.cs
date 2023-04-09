using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetallCategories();
            return View(categories);
        }

        public async Task<ActionResult>Create(CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(dto);
                return PartialView("Index");
            }
            return View(dto);
        }
    }
}
