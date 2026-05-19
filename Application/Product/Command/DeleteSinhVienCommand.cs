using MediatR;

namespace finalproject.Application.Product.Command
{
    public class DeleteSinhVienCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}