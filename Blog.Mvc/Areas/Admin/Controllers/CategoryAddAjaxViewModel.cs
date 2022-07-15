using Blog.Entities.Dtos;

namespace Blog.Mvc.Areas.Admin.Controllers
{
    internal class CategoryAddAjaxViewModel
    {
        public CategoryDto CategoryDto { get; set; }
        public object CategoryAddPartial { get; set; }
    }
}