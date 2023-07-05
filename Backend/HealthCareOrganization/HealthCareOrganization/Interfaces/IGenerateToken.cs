using HealthCareOrganization.Models.DTOs;

namespace HealthCareOrganization.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);

    }

}
