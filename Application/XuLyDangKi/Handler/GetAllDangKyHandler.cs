using finalproject.Application.Interfaces;
using finalproject.Application.XuLyDangKi.Query;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Handler
{
    public class GetAllDangKyHandler : IRequestHandler<GetAllDangKyQuery, IEnumerable<DangKy>>
    {
        private readonly IDangKyRepository _dangKyRepository;
        public GetAllDangKyHandler(IDangKyRepository dangKyRepository)
        {
            _dangKyRepository = dangKyRepository;
        }
        
        public async Task<IEnumerable<DangKy>> Handle(GetAllDangKyQuery request,CancellationToken cancellationToken)
        {
            return await _dangKyRepository.GetAllDangKiesAsync();
        }
        
       
    }
}