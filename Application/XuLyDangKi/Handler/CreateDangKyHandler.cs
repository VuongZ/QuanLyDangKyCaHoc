using finalproject.Application.Interfaces;
using finalproject.Application.XuLyDangKi.Command;
using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Handler
{
    public class CreateDangKyHandler : IRequestHandler<CreateDangKyCommand, bool>
    {
        private readonly IDangKyRepository _dangKyRepository;

        public CreateDangKyHandler(IDangKyRepository dangKyRepository)
        {
            _dangKyRepository = dangKyRepository;
        }

        public async Task<bool> Handle(CreateDangKyCommand request, CancellationToken cancellationToken)
        {
            var dangKy = new DangKy
            {
                Malop = request.IdLopHoc,
                Masinhvien = request.IdSinhVien,
                Ngaydangky = request.NgayDangKy,
                Trangthai = request.TrangThai
            };

            await _dangKyRepository.AddDangKyAsync(dangKy);
            return true;
        }
    }
}