using finalproject.Domain.Entities;
using MediatR;

namespace finalproject.Application.Product.Query
{
   public class GetByIdSinhVienQuery : IRequest<SinhVien>
    {
        public int Id { get; set; }
    }
}