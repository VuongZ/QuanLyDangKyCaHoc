using finalproject.Application.XuLyLopHoc.Command;
using finalproject.Application.XuLyLopHoc.Query;
using finalproject.Presentation.Protos;
using Grpc.Core;
using MediatR;

namespace finalproject.Presentation.Service;
public class LopHocGrpcService : LopHocGrpc.LopHocGrpcBase
{
    private readonly IMediator _mediator;

    public LopHocGrpcService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<GetAllLopHocsResponse> GetAllLopHocs(GetAllLopHocsRequest request, ServerCallContext context)
    {
       var query= new GetAllLopHocQuery();
       var LopHocs= await _mediator.Send(query);
       var response = new GetAllLopHocsResponse();
       response.LopHocs.AddRange(LopHocs.Select(l => new LopHoc
       {
           Id = l.Id,
           Tenlop = l.Tenlop,
           Sophong = l.Sophong
       }));
       return response;
    }
    public override async Task<LopHocResponse> GetLopHocById(GetLopHocByIdRequest request,ServerCallContext context)
    {
        var query = new GetByIDLopHocQuery{Id=request.Id};
        var LopHoc= await _mediator.Send(query); 
        if(LopHoc == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Lop Hoc with ID {request.Id} not found"));

        }
        return new LopHocResponse
        {
            Id = LopHoc.Id,
            Tenlop= LopHoc.Tenlop,
            Sophong= LopHoc.Sophong
        };
    }
    public override async Task<CreateLopHocResponse> CreateLopHoc(CreateLopHocRequest request,ServerCallContext context)
    {
        var command= new CreateLopHocCommand
        {
            Tenlop = request.Tenlop,
            Sophong = request.Sophong
        };
        var id = await _mediator.Send(command);
        return new CreateLopHocResponse {Id = id};
    }
    public override async Task<UpdateLopHocResponse> UpdateLopHoc(UpdateLopHocRequest request,ServerCallContext context)
    {
        var command= new UpdateLopHocCommand
        {
            Id=request.Id,
            Tenlop=request.Tenlop,
            Sophong=request.Sophong
        };
        await _mediator.Send(command);
        return new UpdateLopHocResponse{Success=true};
    }
    public override async Task<DeleteLopHocResponse> DeleteLopHoc(DeleteLopHocRequest request,ServerCallContext context)
    {
        var command= new DeleteLopHocCommand
        {
            Id = request.Id
        };
        await _mediator.Send(command);
    return new DeleteLopHocResponse{Success=true};

    }
}