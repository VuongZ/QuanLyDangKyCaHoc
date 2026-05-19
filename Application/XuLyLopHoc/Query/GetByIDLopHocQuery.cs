using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyLopHoc.Query
{
    public class GetByIDLopHocQuery : IRequest<LopHoc?>
    {
        public int Id { get; set; }
    }
}