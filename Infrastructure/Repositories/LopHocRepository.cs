using finalproject.Application.Interfaces;
using finalproject.Domain.Entities;
using finalproject.Presentation.Data;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Infrastructure.Repositories
{
    public class LopHocRepository : ILopHocRepository
    {
        private readonly AppDbContext _context;
        public LopHocRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LopHoc>> GetAllLopHocsAsync()
        {
            return await _context.LopHocs.ToListAsync();
        }
        public async Task<LopHoc> GetLopHocByIdAsync(int id)
        {
            return await _context.LopHocs.FindAsync(id);
        }
        public async Task<int> AddLopHocAsync(LopHoc lopHoc)
        {
            _context.LopHocs.Add(lopHoc);
            await _context.SaveChangesAsync();
            return lopHoc.Id; // Trả về ID của lớp học vừa thêm
        }
        public async Task UpdateLopHocAsync(LopHoc lopHoc)
        {
            _context.LopHocs.Update(lopHoc);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteLopHocAsync(int id)
        {
            var lopHoc = await _context.LopHocs.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHocs.Remove(lopHoc);
                await _context.SaveChangesAsync();
            }
        }
    }
}