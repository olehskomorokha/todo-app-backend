using TodoApp.Interfaces.Interfaces;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Mappers;
using TodoApp.Services.Models.Category;

namespace TodoApp.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(CategoryMapper.MapToCategoryDto).ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        return CategoryMapper.MapToCategoryDto(await _categoryRepository.GetByIdAsync(id));
    }

    public async Task AddAsync(AddCategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            throw new ArgumentNullException(nameof(categoryDto));
        }

        await _categoryRepository.AddAsync(CategoryMapper.MapToAddCategory(categoryDto));
    }

    public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
    {
        var categoryToUpdate = await _categoryRepository.GetByIdAsync(id);

        if (categoryToUpdate == null)
        {
            throw new ArgumentNullException(nameof(categoryToUpdate));
        }

        if (categoryDto == null)
        {
            throw new ArgumentNullException(nameof(categoryDto));
        }

        categoryToUpdate.Name = categoryDto.Name;
        await _categoryRepository.UpdateAsync(categoryToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var categoryToDelete = await _categoryRepository.GetByIdAsync(id);
        if (categoryToDelete == null)
        {
            throw new ArgumentNullException(nameof(categoryToDelete));
        }

        await _categoryRepository.DeleteAsync(categoryToDelete);
    }
}