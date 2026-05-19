using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.XuLyLopHoc.Query
{
    public class GetAllLopHocQuery : IRequest<IEnumerable<LopHoc>>
    {
    }
}