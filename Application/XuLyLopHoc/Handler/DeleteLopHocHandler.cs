using finalproject.Application.Interfaces;
using finalproject.Application.XuLyLopHoc.Command;
using MediatR;

namespace finalproject.Application.XuLyLopHoc.Handler
{
    public class DeleteLopHocHandler : IRequestHandler<DeleteLopHocCommand, bool>
    {
       private readonly ILopHocRepository _lopHocRepository;

        public DeleteLopHocHandler(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }

        public async Task<bool> Handle(DeleteLopHocCommand request, CancellationToken cancellationToken)
        {
            await _lopHocRepository.DeleteLopHocAsync(request.Id);
            return true;
        }
    }
}