using finalproject.Application.Interfaces;
using finalproject.Domain.Entities;
using finalproject.Presentation.Data;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Infrastructure.Repositories
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly AppDbContext _context;

        public SinhVienRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SinhVien>> GetAllSinhViensAsync()
        {
            return await _context.SinhViens.ToListAsync();
        }

        public async Task<SinhVien> GetSinhVienByIdAsync(int id)
        {
            return await _context.SinhViens.FindAsync(id);
        }

        public async Task<int> AddSinhVienAsync(SinhVien sinhVien)
        {
            _context.SinhViens.Add(sinhVien);
            await _context.SaveChangesAsync();
            return sinhVien.Id; // Trả về ID của sinh viên vừa thêm
        }

        public async Task UpdateSinhVienAsync(SinhVien sinhVien)
        {
           _context.SinhViens.Update(sinhVien);
                await _context.SaveChangesAsync();
        }

        public async Task DeleteSinhVienAsync(int id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}