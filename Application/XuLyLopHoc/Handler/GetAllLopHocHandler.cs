using finalproject.Application.Interfaces;
using finalproject.Application.XuLyLopHoc.Query;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyLopHoc.Handler
{
    public class GetAllLopHocHandler : IRequestHandler<GetAllLopHocQuery, IEnumerable<LopHoc>>
    {
        private readonly ILopHocRepository _lopHocRepository;
        public GetAllLopHocHandler(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }
        public async Task<IEnumerable<LopHoc>> Handle(GetAllLopHocQuery request, CancellationToken cancellationToken)
        {
            return await _lopHocRepository.GetAllLopHocsAsync();
        }
        
    }
}