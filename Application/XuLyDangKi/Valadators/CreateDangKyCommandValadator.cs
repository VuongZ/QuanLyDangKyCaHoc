using finalproject.Application.XuLyDangKi.Command;
using FluentValidation;

namespace finalproject.Application.XuLyDangKi.Valadators;
public class CreateDangKyCommandValadator : AbstractValidator<CreateDangKyCommand>
{
    public CreateDangKyCommandValadator()
    {
        RuleFor(x=> x.IdSinhVien).GreaterThan(0).WithMessage("ID Sinh Vien khong Hop Le");

            RuleFor(x => x.IdLopHoc)
                .GreaterThan(0).WithMessage("IdLopHoc không hợp lệ");

            RuleFor(x => x.NgayDangKy)
                .NotEmpty().WithMessage("Ngày đăng ký không được để trống");
    }
}