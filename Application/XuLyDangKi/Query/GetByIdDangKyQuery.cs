using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Query
{
    public class GetByIdDangKyQuery : IRequest<DangKy>
    {
        public int IdSinhVien { get; set; }
        public int IdLopHoc { get; set; }
    }
}