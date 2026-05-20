using finalproject.Application.Interfaces;
using finalproject.Application.XuLyDangKi.Command;
using finalproject.Domain.Entities;
using finalproject.Infrastructure.Messaging;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Handler
{
    public class CreateDangKyHandler : IRequestHandler<CreateDangKyCommand, bool>
    {
        private readonly IDangKyRepository _dangKyRepository;
        private readonly RabbiMqPublisher _publisher;

        public CreateDangKyHandler(IDangKyRepository dangKyRepository,RabbiMqPublisher pulisher)
        {
            _dangKyRepository = dangKyRepository;
            _publisher=pulisher;
        }

        public async Task<bool> Handle(CreateDangKyCommand request, CancellationToken cancellationToken)
        {
            var dangKy = new DangKy
            {
                Malop = request.IdLopHoc,
                Masinhvien = request.IdSinhVien,
                Ngaydangky = request.NgayDangKy,
                Trangthai = request.TrangThai ?? "Cho Xac Nhan"
            };

            var result =  await _dangKyRepository.AddDangKyAsync(dangKy);
              if (result)
                 _publisher.PublishDangKySucess(request.IdSinhVien, request.IdLopHoc);
            return result;
        }
    }
}