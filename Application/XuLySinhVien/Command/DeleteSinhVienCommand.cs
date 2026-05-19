using MediatR;

namespace finalproject.Application.XuLySinhVien.Command
{
    public class DeleteSinhVienCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}