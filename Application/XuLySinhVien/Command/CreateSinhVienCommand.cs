using MediatR;
namespace finalproject.Application.XuLySinhVien.Command
{
    public class CreateSinhVienCommand : IRequest<int>
    {
        public string? MaSv { get; set; }
        public string? Tensv { get; set; }
    }
}