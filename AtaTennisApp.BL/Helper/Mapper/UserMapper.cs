using AtaTennisApp.BL.DTO;
using AtaTennisApp.Data.Entities;

namespace AtaTennisApp.BL.Helper.Mapper
{
    public static class UserMapper
    {
        public static UserDTO MapToDTO(User user)
        {
            if (user == null)
                return null;

            return new UserDTO
            {
                Username = user.Username,
                Password = user.Password
            };
        }

        public static User MapToEntity(UserDTO userDTO)
        {
            if (userDTO == null)
                return null;

            return new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password
            };
        }
    }
}
