using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TodoApp.Interfaces.Interfaces;
using TodoApp.Services.Exceptions;
using TodoApp.Services.Helpers;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Mappers;
using TodoApp.Services.Models.User;

namespace TodoApp.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(UserMapper.MapToUserDto).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        return UserMapper.MapToUserDto(await _userRepository.GetByIdAsync(id));
    }

    public async Task AddAsync(AddUserDto userDto)
    {
        var user = UserMapper.MapToAddUser(userDto);
        await _userRepository.AddAsync(user);
    }

    public async Task UpdateAsync(int id, UpdateUserDto userDto)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(id);

        if (userDto.Email != null)
        {
            userToUpdate.Email = userDto.Email;
        }

        if (userDto.Password != null)
        {
            userToUpdate.Password = userDto.Password;
        }

        if (userDto.Username != null)
        {
            userToUpdate.Username = userDto.Username;
        }

        await _userRepository.UpdateAsync(userToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var userToDelete = await _userRepository.GetByIdAsync(id);
        if (userToDelete == null)
        {
            throw new KeyNotFoundException();
        }

        await _userRepository.DeleteAsync(userToDelete);
    }
}