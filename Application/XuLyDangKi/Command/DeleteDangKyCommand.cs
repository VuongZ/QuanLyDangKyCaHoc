using MediatR;

namespace finalproject.Application.XuLyDangKi.Command
{
    public class DeleteDangKyCommand : IRequest<bool>
    {
        public int IdLop { get; set; }
        public int IdSinhVien { get; set; }
    }
}