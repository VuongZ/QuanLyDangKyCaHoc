using finalproject.Application.Interfaces;
using finalproject.Application.XuLyLopHoc.Query;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyLopHoc.Handler
{
    public class GetByIDLopHocHandler : IRequestHandler<GetByIDLopHocQuery, LopHoc?>
    {
        private readonly ILopHocRepository _lopHocRepository;
        public GetByIDLopHocHandler(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }
        public async Task<LopHoc?> Handle(GetByIDLopHocQuery request, CancellationToken cancellationToken)
        {
            return await _lopHocRepository.GetLopHocByIdAsync(request.Id);
        }
        
    }
}