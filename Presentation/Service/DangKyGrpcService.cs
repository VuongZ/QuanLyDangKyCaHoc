using System.Runtime.Serialization.DataContracts;
using finalproject.Application.XuLyDangKi.Command;
using finalproject.Application.XuLyDangKi.Query;
using finalproject.Presentation.Protos;
using Grpc.Core;
using MediatR;

namespace finalproject.Presentation.Service;
public class DangKyGrpcService : DangKyGrpc.DangKyGrpcBase
{
    private readonly IMediator _imediator;
    public DangKyGrpcService(IMediator imediator)
    {
        _imediator = imediator;
    }
    public override async Task<GetAllDangKiesResponse> GetAllDangKies(GetAllDangKiesRequest request,ServerCallContext context)
    {
        var query= new GetAllDangKyQuery();
        var DangKys= await _imediator.Send(query);
        var respone= new GetAllDangKiesResponse();
        respone.DangKies.AddRange(DangKys.Select(dk => new DangKy
        {
            IdLop=dk.Malop,
            IdSinhVien = dk.Masinhvien,
            NgayDangKy=dk.Ngaydangky.ToString("yyyy-MM-dd"),
            TrangThai=dk.Trangthai
        }
        ));
        return respone;
        
    }
    public override async Task<DangKyResponse> GetDangKyById(GetDangKyByIdRequest request,ServerCallContext context)
    {
        var query= new GetByIdDangKyQuery{IdLopHoc=request.IdLop,IdSinhVien=request.IdSinhVien};
        var dangKy=await _imediator.Send(query);
        if(dangKy==null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Lop Hoc with ID {request.IdLop} not found"));
        }
        return new DangKyResponse
        {
            IdLop=dangKy.Malop,
            IdSinhVien=dangKy.Masinhvien,
            NgayDangKy=dangKy.Ngaydangky.ToString("yyyy-MM-dd"),
            TrangThai=dangKy.Trangthai
        };
    }
    public override async Task<CreateDangKyResponse> CreateDangKy(CreateDangKyRequest request, ServerCallContext context )
    {
        var command= new CreateDangKyCommand
        {
          IdLopHoc=request.IdLop,
            IdSinhVien=request.IdSinhVien,
            NgayDangKy=DateOnly.Parse(request.NgayDangKy),
            TrangThai=request.TrangThai
        };
        await _imediator.Send(command);
        return new CreateDangKyResponse {Success=true};
    }
    public override async Task<UpdateDangKyResponse> UpdateDangKy(UpdateDangKyRequest request,ServerCallContext context)
    {
        var command = new UpdateDangKyCommand
        {
          IdLopHoc=request.IdLop,
            IdSinhVien=request.IdSinhVien,
            NgayDangKy=DateOnly.Parse(request.NgayDangKy),
            TrangThai=request.TrangThai
        };
           await _imediator.Send(command);
        return new UpdateDangKyResponse {Success=true};
    }
    public override async Task<DeleteDangKyResponse> DeleteDangKy(DeleteDangKyRequest request,ServerCallContext context)
    {
        var command=new DeleteDangKyCommand
        {
              IdLop=request.IdLop,
            IdSinhVien=request.IdSinhVien
        };
         await _imediator.Send(command);
        return new DeleteDangKyResponse {Success=true};
    }

}