using APINewsFeed.BLL.DTO.UserDTOs;

namespace APINewsFeed.BLL.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUser(Guid id);
        Task<List<UsersDTO>> GetUsers(GetUsersDTO getUserDTO);
        Task<Guid> UserRegistration(UserRegistrationDTO userRegistration);
        Task<Guid> UserAuthorization(UserAuthorizationDTO userAuthorization);
        Task<UpdateUserDTO> UpdateUser(UpdateUserDTO updateUserDTO);
        Task<Guid> DeleteUser(Guid id);

    }
}
