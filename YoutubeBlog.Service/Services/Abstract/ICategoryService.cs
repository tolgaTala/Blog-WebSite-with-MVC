using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryDto>> GetAllDeletedCategories();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
    }
}
