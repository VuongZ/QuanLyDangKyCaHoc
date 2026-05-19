using finalproject.Domain.Entities;

namespace finalproject.Application.Interfaces
{
    public interface ISinhVienRepository
    {
        Task<IEnumerable<SinhVien>> GetAllSinhViensAsync();
        Task<SinhVien> GetSinhVienByIdAsync(int id);
        Task<int> AddSinhVienAsync(SinhVien sinhVien);
        Task UpdateSinhVienAsync(SinhVien sinhVien);
        Task DeleteSinhVienAsync(int id);
    }
}