using finalproject.Application.Interfaces;
using finalproject.Application.XuLyLopHoc.Command;
using MediatR;

namespace finalproject.Application.XuLyLopHoc.Handler
{
    public class UpdateLopHocHandler : IRequestHandler<UpdateLopHocCommand, bool> 
    {
        private readonly ILopHocRepository _lopHocRepository;
        public UpdateLopHocHandler(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }
        public async Task<bool> Handle(UpdateLopHocCommand request, CancellationToken cancellationToken)
        {
            var lopHoc = await _lopHocRepository.GetLopHocByIdAsync(request.Id);
            if (lopHoc == null)
            {
                return false;
            }

            lopHoc.Tenlop = request.Tenlop;
            lopHoc.Sophong = request.Sophong;

            await _lopHocRepository.UpdateLopHocAsync(lopHoc);
            return true;
        }
     
    }
}