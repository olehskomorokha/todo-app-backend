using TodoApp.Data.Entities;
using TodoApp.Services.Models.User;

namespace TodoApp.Services.Mappers;

public static class UserMapper
{
    public static UserDto MapToUserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
            Password = user.Password
        };
    }

    public static User MapToAddUser(AddUserDto userDto)
    {
        return new User()
        {
            Email = userDto.Email,
            Username = userDto.Username,
            Password = userDto.Password,
        };
    }
}