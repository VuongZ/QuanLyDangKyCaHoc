using finalproject.Domain.Entities;

namespace   finalproject.Application.Interfaces
{
    public interface IDangKyRepository
    {
        Task<IEnumerable<DangKy>> GetAllDangKiesAsync();
        Task<DangKy> GetDangKyByIdAsync(int idLop, int idSinhVien);
        Task<bool> AddDangKyAsync(DangKy dangKy);
        Task UpdateDangKyAsync(DangKy dangKy);
        Task DeleteDangKyAsync(int idLop, int idSinhVien);
    }
}