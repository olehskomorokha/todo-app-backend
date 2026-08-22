using Microsoft.AspNetCore.Mvc;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Models.Category;

namespace TodoApp.Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _categoryService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddCategoryDto categoryDto)
    {
        await _categoryService.AddAsync(categoryDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateCategoryDto categoryDto)
    {
        await _categoryService.UpdateAsync(id,  categoryDto);
        return Ok();
    }
}