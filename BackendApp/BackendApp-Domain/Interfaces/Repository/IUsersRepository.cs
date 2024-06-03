using BackendApp_Domain.DTO;

namespace BackendApp_Domain.Interfaces.Repository
{
    public interface IUsersRepository
    {
        Task<UserDTO?> Get(string email);
        Task<UserDTO?> Get(string email, string password);
    }
}
