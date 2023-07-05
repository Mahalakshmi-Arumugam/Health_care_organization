using HealthCareOrganization.Models.DTOs;
using HealthCareOrganization.Models;

namespace HealthCareOrganization.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(UserDTO user);
        public Task<UserDTO> RegisterPatient(Patient patient);
        public Task<UserDTO> RegisterDoctor(Doctor doctor);
        public Task<Doctor> Approval(int DoctorId);

    }

}
