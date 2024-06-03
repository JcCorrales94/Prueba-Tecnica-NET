using BackendApp_Domain.DTO.Request;
using BackendApp_Domain.DTO.Response;
using BackendApp_Domain.Interfaces.Repository;
using BackendApp_Domain.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendApp_Infrastructure.Service
{
    public class UsersService : IUsersService
    {
        readonly IUsersRepository _usersRepository;
        readonly IConfiguration _configuration;
        readonly IEncryptionService _encryptionService;

        public UsersService(IUsersRepository usersRepository, IConfiguration configuration, IEncryptionService encryptionServices)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _encryptionService = encryptionServices;
        }
        public async Task<AuthenticateResponseDTO> Login(LoginRequest loginRequest)
        {
            var user = await _usersRepository.Get(loginRequest.Email);

            if (user == null)
            {
                throw new InvalidDataException("El usuario o la contraseña no son correcta");
            }

            var descrytedPassword = _encryptionService.DecryptString(user.Password);
            if (descrytedPassword != loginRequest.Password)
            {
                throw new InvalidDataException("El usuario o la contraseña no son correcta");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JWT:ValidAudience"],
                Issuer = _configuration["JWT:ValidIssuer"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var authenticateResponse = new AuthenticateResponseDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Token = tokenHandler.WriteToken(token),
            };
            return authenticateResponse;
        }
    }
}
