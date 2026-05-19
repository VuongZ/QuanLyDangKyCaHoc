using finalproject.Application.Interfaces;
using finalproject.Application.XuLySinhVien.Command;
using MediatR;

namespace finalproject.Application.XuLySinhVien.Handler
{
    public class DeleteSinhVienHandler : IRequestHandler<DeleteSinhVienCommand, bool>
    {
        private readonly ISinhVienRepository _sinhVienRepository;

        public DeleteSinhVienHandler(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }

        public async Task<bool> Handle(DeleteSinhVienCommand request, CancellationToken cancellationToken)
        {
            await _sinhVienRepository.DeleteSinhVienAsync(request.Id);
            return true;
        }
        
    }
}