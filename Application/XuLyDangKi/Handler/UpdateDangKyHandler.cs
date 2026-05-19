using finalproject.Application.Interfaces;
using finalproject.Application.XuLyDangKi.Command;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Handler
{
    public class UpdateDangKyHandler : IRequestHandler<UpdateDangKyCommand, bool>
    {
        private readonly IDangKyRepository _dangKyRepository;

        public UpdateDangKyHandler(IDangKyRepository dangKyRepository)
        {
            _dangKyRepository = dangKyRepository;
        }

        public async Task<bool> Handle(UpdateDangKyCommand request, CancellationToken cancellationToken)
        {
            var existingDangKy = await _dangKyRepository.GetDangKyByIdAsync(request.IdLopHoc, request.IdSinhVien);
            if (existingDangKy == null)
            {
                return false; 
            }

            existingDangKy.Ngaydangky = request.NgayDangKy;
            existingDangKy.Trangthai = request.TrangThai;

            await _dangKyRepository.UpdateDangKyAsync(existingDangKy);
            return true;
        }
    }
}