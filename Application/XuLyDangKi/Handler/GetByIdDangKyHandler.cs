using finalproject.Application.Interfaces;
using finalproject.Application.XuLyDangKi.Query;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Handler
{
    public class GetByIdDangKyHandler : IRequestHandler<GetByIdDangKyQuery, DangKy>
    {
        private readonly IDangKyRepository _dangKyRepository;
        public GetByIdDangKyHandler(IDangKyRepository dangKyRepository)
        {
            _dangKyRepository = dangKyRepository;
        }
        
        public async Task<DangKy> Handle(GetByIdDangKyQuery request,CancellationToken cancellationToken)
        {
            return await _dangKyRepository.GetDangKyByIdAsync(request.IdSinhVien,request.IdLopHoc);
        }
    }
}