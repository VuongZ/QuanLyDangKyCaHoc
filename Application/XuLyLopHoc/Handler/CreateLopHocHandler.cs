using finalproject.Application.Interfaces;
using finalproject.Application.XuLyLopHoc.Command;
using finalproject.Domain.Entities;
using MediatR;
namespace finalproject.Application.XuLyLopHoc.Handler
{
    public class CreateLopHocHandler : IRequestHandler<CreateLopHocCommand, int>

    {
        private readonly ILopHocRepository _lopHocRepository;
        public CreateLopHocHandler(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }
        public async Task<int> Handle(CreateLopHocCommand request, CancellationToken cancellationToken)
        {
            var lopHoc = new LopHoc
            {
                Tenlop  =  request.Tenlop,
                Sophong = request.Sophong,
            };

            return await _lopHocRepository.AddLopHocAsync(lopHoc);
        }
       
    }
}