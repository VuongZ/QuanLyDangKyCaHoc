using finalproject.Application.Interfaces;
using finalproject.Application.Product.Query;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.Product.Handler
{
    public class GetAllSinhVienHandler : IRequestHandler<GetALLSinhVienQuery, IEnumerable<SinhVien>>
    {
        private readonly ISinhVienRepository _sinhVienRepository;

        public GetAllSinhVienHandler(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }

        public async Task<IEnumerable<SinhVien>> Handle(GetALLSinhVienQuery request, CancellationToken cancellationToken)
        {
            return await _sinhVienRepository.GetAllSinhViensAsync();
        }
    }
}