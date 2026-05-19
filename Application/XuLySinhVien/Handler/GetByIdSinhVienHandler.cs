using finalproject.Application.Interfaces;
using finalproject.Application.XuLySinhVien.Query;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLySinhVien.Handler
{
    public class GetByIdSinhVienHandler : IRequestHandler<GetByIdSinhVienQuery, SinhVien>
    {
        private readonly ISinhVienRepository _sinhVienRepository;

        public GetByIdSinhVienHandler(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }

        public async Task<SinhVien> Handle(GetByIdSinhVienQuery request, CancellationToken cancellationToken)
        {
            return await _sinhVienRepository.GetSinhVienByIdAsync(request.Id);
        }
    }
}
