using finalproject.Application.Interfaces;
using finalproject.Application.Product.Command;
using MediatR;

namespace finalproject.Application.Product.Handler
{
   public class UpdateSinhVienHandler : IRequestHandler<UpdateSinhVienCommand, bool>
    {
        private readonly ISinhVienRepository _sinhVienRepository;
        public UpdateSinhVienHandler(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }
        public async Task<bool> Handle(UpdateSinhVienCommand request, CancellationToken cancellationToken)
        {
            var sinhVien = await _sinhVienRepository.GetSinhVienByIdAsync(request.Id);
            if (sinhVien == null)
            {
                return false;
            }
            sinhVien.Mssv = request.MaSv;
            sinhVien.Tensv = request.Tensv;

            await _sinhVienRepository.UpdateSinhVienAsync(sinhVien);
            return true;
        }
    }
}