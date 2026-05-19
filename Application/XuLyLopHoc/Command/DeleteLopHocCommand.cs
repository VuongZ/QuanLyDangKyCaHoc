using MediatR;

namespace finalproject.Application.XuLyLopHoc.Command
{
    public class DeleteLopHocCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}