using finalproject.Domain.Entities;

namespace finalproject.Application.Interfaces
{
    public interface ILopHocRepository
    {
        Task<IEnumerable<LopHoc>> GetAllLopHocsAsync();
        Task<LopHoc> GetLopHocByIdAsync(int id);
        Task AddLopHocAsync(LopHoc lopHoc);
        Task UpdateLopHocAsync(LopHoc lopHoc);
        Task DeleteLopHocAsync(int id);
    }
}