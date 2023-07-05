using HealthCareOrganization.Interfaces;
using HealthCareOrganization.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareOrganization.Services
{
    public class PatientRepo : IRepo<int, Patient>
    {
        private readonly Context _context;
        private readonly ILogger<User> _logger;

        public PatientRepo(Context context, ILogger<User> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Patient?> Add(Patient item)
        {
            try
            {
                _context.Patients.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Patient?> Delete(int key)
        {

            try
            {
                var patient = await Get(key);
                if (patient != null)
                {
                    _context.Patients.Remove(patient);
                    await _context.SaveChangesAsync();
                    return patient;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Patient?> Get(int key)
        {
            try
            {
                var patient = await _context.Patients.Include(i => i.User).FirstOrDefaultAsync(i => i.PatientId == key);
                return patient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Patient>?> GetAll()
        {
            try
            {
                var patient = await _context.Patients.Include(i => i.User).ToListAsync();
                if (patient.Count > 0)
                    return patient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Patient?> Update(Patient item)
        {
            try
            {
                var patient = await Get(item.PatientId);
                if (patient != null)
                {
                    patient.PatientId = item.PatientId;
                    patient.PatientName = item.PatientName;
                    patient.User = item.User;
                    patient.Email = item.Email;
                    patient.PhoneNo = item.PhoneNo;
                    patient.DOB = item.DOB;
                    patient.Age = item.Age;
                    patient.Affliction = item.Affliction;
                    patient.Gender = item.Gender;
                    return patient;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}

