using HealthCareOrganization.Models;

namespace HealthCareOrganization.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePasswordDoctor(Doctor doctor);
        public Task<string?> GeneratePasswordPatient(Patient patient);

    }

}
