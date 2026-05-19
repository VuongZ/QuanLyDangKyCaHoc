using finalproject.Presentation.Protos;
using Grpc.Core;
using MediatR;
namespace finalproject.Presentation.Service
{
    public class SinhVienGrpcService : SinhVienGrpc.SinhVienGrpcBase
    {
        private readonly IMediator _mediator;
        public SinhVienGrpcService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<GetAllSinhViensResponse> GetAllSinhViens(GetAllSinhViensRequest request, ServerCallContext context)
        {
            var query = new Application.XuLySinhVien.Query.GetALLSinhVienQuery();
            var sinhViens = await _mediator.Send(query);
            var response = new GetAllSinhViensResponse();
            response.SinhViens.AddRange(sinhViens.Select(s => new SinhVien
            {
                Id = s.Id,
                Tensv = s.Tensv,
                Mssv = s.Mssv
            }
        ));
            return response;
        }
        public override async Task<SinhVienResponse> GetSinhVienById(GetSinhVienByIdRequest request, ServerCallContext context)
        {
            var query = new Application.XuLySinhVien.Query.GetByIdSinhVienQuery { Id = request.Id };
            var sinhVien = await _mediator.Send(query);
            if (sinhVien == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"SinhVien with ID {request.Id} not found"));
            }
            return new SinhVienResponse
            {
                Id = sinhVien.Id,
                Tensv = sinhVien.Tensv,
                Mssv = sinhVien.Mssv
            };
        }
        public override async Task<CreateSinhVienResponse> CreateSinhVien(CreateSinhVienRequest request, ServerCallContext context)
        {
            var command = new Application.XuLySinhVien.Command.CreateSinhVienCommand
            {
                Tensv = request.Tensv,
                MaSv = request.Mssv
            };
            var id = await _mediator.Send(command);
            return new CreateSinhVienResponse { Id = id };
        }
        public override async Task<UpdateSinhVienResponse> UpdateSinhVien(UpdateSinhVienRequest request, ServerCallContext context)
        {
            var command = new Application.XuLySinhVien.Command.UpdateSinhVienCommand
            {
                Id = request.Id,
                Tensv = request.Tensv,
                MaSv = request.Mssv
            };
            await _mediator.Send(command);
            return new UpdateSinhVienResponse { Success = true };
        } 
        public override async Task<DeleteSinhVienResponse> DeleteSinhVien(DeleteSinhVienRequest request, ServerCallContext context)
        {
            var command = new Application.XuLySinhVien.Command.DeleteSinhVienCommand
            {
                Id = request.Id
            };
            await _mediator.Send(command);
            return new DeleteSinhVienResponse { Success = true };
        }
    }
}