using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyDangKi.Query
{
    public class GetAllDangKyQuery : IRequest<IEnumerable<DangKy>>
    {
    }
}