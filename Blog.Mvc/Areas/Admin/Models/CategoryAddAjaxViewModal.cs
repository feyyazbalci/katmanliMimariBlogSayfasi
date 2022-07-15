using Blog.Entities.Dtos;

namespace Blog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModal
    {
        public CategoryAddDto CategoryAddDto { get; set; }

        public string CategoryAddPartial { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}
