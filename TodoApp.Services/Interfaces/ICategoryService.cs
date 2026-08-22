using TodoApp.Services.Models.Category;

namespace TodoApp.Services.Interfaces;

public interface ICategoryService
{
    public Task<List<CategoryDto>> GetAllAsync();
    public Task<CategoryDto> GetByIdAsync(int id);
    public Task AddAsync(AddCategoryDto categoryDto);
    public Task UpdateAsync(int id, UpdateCategoryDto categoryDto);
    public Task DeleteAsync(int id);
}