using MediatR;

namespace finalproject.Application.XuLyLopHoc.Command
{
    public class CreateLopHocCommand : IRequest<int>
    {
        public string? Tenlop { get; set; }
        public string? Sophong { get; set; }
    }
}