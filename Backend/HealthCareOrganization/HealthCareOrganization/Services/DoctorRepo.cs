using HealthCareOrganization.Interfaces;
using HealthCareOrganization.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareOrganization.Services
{
    public class DoctorRepo : IRepo<int, Doctor>
    {
        private readonly Context _context;
        private readonly ILogger<User> _logger;

        public DoctorRepo(Context context, ILogger<User> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Doctor?> Add(Doctor item)
        {

            try
            {
                _context.Doctors.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Doctor?> Delete(int key)
        {
            try
            {
                var doc = await Get(key);
                if (doc != null)
                {
                    _context.Doctors.Remove(doc);
                    await _context.SaveChangesAsync();
                    return doc;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Doctor?> Get(int key)
        {
            try
            {
                var doc = await _context.Doctors.FirstOrDefaultAsync(i => i.DoctorId == key);
                return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Doctor>?> GetAll()
        {

            try
            {
                var doc = await _context.Doctors.ToListAsync();
                if (doc.Count > 0)
                    return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            try
            {
                var existingDoctor = await _context.Doctors.FindAsync(item.DoctorId);
                if (existingDoctor != null)
                {
                    existingDoctor.DoctorName = item.DoctorName;
                    existingDoctor.User = item.User;
                    existingDoctor.Email = item.Email;
                    existingDoctor.PhoneNo = item.PhoneNo;
                    existingDoctor.DOB = item.DOB;
                    existingDoctor.Age = item.Age;
                    existingDoctor.Gender = item.Gender;

                    await _context.SaveChangesAsync(); // Save the changes to the database

                    return existingDoctor;
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
