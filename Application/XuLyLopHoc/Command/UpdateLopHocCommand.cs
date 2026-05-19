using MediatR;

namespace finalproject.Application.XuLyLopHoc.Command
{
    public class UpdateLopHocCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Tenlop { get; set; }
        public string? Sophong { get; set; }
    }
}