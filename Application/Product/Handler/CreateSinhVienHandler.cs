using finalproject.Application.Interfaces;
using finalproject.Application.Product.Command;
using finalproject.Domain.Entities;
using MediatR;
namespace finalproject.Application.Product.Handler
{
 public class CreateSinhVienHandler : IRequestHandler<CreateSinhVienCommand, int>
    {
        private readonly ISinhVienRepository _sinhVienRepository;

        public CreateSinhVienHandler(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }

        public async Task<int> Handle(CreateSinhVienCommand request, CancellationToken cancellationToken)
        {
            var sinhVien = new SinhVien
            {
                Mssv = request.MaSv,
                Tensv = request.Tensv
            };

          return await _sinhVienRepository.AddSinhVienAsync(sinhVien);
        }
    }
}