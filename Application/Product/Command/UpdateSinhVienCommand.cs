using MediatR;

namespace finalproject.Application.Product.Command
{
    public class UpdateSinhVienCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? MaSv { get; set; }
        public string? Tensv { get; set; }
    }
  
}