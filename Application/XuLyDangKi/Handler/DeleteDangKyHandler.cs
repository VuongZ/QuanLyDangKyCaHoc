using finalproject.Application.Interfaces;
using finalproject.Application.XuLyDangKi.Command;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Handler
{
    public class DeleteDangKyHandler : IRequestHandler<DeleteDangKyCommand, bool>
    {
        private readonly IDangKyRepository _dangKyRepository;

        public DeleteDangKyHandler(IDangKyRepository dangKyRepository)
        {
            _dangKyRepository = dangKyRepository;
        }

        public async Task<bool> Handle(DeleteDangKyCommand request, CancellationToken cancellationToken)
        {
            await _dangKyRepository.DeleteDangKyAsync(request.IdLop, request.IdSinhVien);
            return true;
        }
    }
}