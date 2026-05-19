using finalproject.Domain.Entities;

namespace   finalproject.Application.Interfaces
{
    public interface IDangKyRepository
    {
        Task<IEnumerable<DangKy>> GetAllDangKiesAsync();
        Task<DangKy> GetDangKyByIdAsync(int id);
        Task AddDangKyAsync(DangKy dangKy);
        Task UpdateDangKyAsync(DangKy dangKy);
        Task DeleteDangKyAsync(int id);
    }
}