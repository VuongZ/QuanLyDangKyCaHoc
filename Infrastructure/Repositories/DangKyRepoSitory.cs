using finalproject.Application.Interfaces;
using finalproject.Domain.Entities;
using finalproject.Presentation.Data;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Infrastructure.Repositories
{
   public class DangKyRepoSitory : IDangKyRepository
    {
        private readonly AppDbContext _context;
        public DangKyRepoSitory(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DangKy>> GetAllDangKiesAsync()
        {
            return await _context.DangKy.ToListAsync();
        }
        public async Task<DangKy> GetDangKyByIdAsync(int idLop, int idSinhVien)
        {
            return await _context.DangKy.FindAsync(idLop, idSinhVien);
        }
        public async Task<bool> AddDangKyAsync(DangKy dangKy)
        {
            _context.DangKy.Add(dangKy);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task UpdateDangKyAsync(DangKy dangKy)
        {
            _context.DangKy.Update(dangKy);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDangKyAsync(int idLop, int idSinhVien)
        {
            var dangKy = await _context.DangKy.FindAsync(idLop, idSinhVien);
            if (dangKy != null)
            {
                _context.DangKy.Remove(dangKy);
                await _context.SaveChangesAsync();
            }
        }
    }
}