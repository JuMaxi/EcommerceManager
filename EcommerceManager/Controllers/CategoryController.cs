using EcommerceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceManager.Controllers
{
    [ApiController]
    [Route("[]Controller")]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
