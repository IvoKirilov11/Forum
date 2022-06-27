using Forum.Data.Models;
using Forum.Services.Mapping;

namespace Forum.Web.ViewModels.Posts
{
    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}