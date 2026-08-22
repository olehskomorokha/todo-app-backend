using TodoApp.Data.Entities;
using TodoApp.Services.Models.Category;

namespace TodoApp.Services.Mappers;

public static class CategoryMapper
{
    public static CategoryDto MapToCategoryDto(Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static Category MapToAddCategory(AddCategoryDto categoryDto)
    {
        return new Category()
        {
            Name = categoryDto.Name
        };
    }
}