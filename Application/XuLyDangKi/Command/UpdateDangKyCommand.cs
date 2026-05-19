using MediatR;

namespace finalproject.Application.XuLyDangKi.Command
{
    public class UpdateDangKyCommand : IRequest<bool>
    {

        public int IdSinhVien { get; set; }
        public int IdLopHoc { get; set; }
        public DateOnly NgayDangKy { get; set; }
        public string? TrangThai { get; set; }
    }
}