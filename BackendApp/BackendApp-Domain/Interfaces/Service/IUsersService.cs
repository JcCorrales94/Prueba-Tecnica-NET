using BackendApp_Domain.DTO.Request;
using BackendApp_Domain.DTO.Response;


namespace BackendApp_Domain.Interfaces.Service
{
    public interface IUsersService
    {
        Task<AuthenticateResponseDTO> Login(LoginRequest loginRequest);
    }
}
