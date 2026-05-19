using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Domain.Entities;

[PrimaryKey("Malop", "Masinhvien")]
[Table("DangKy")]
public partial class DangKy
{
    [Key]
    [Column("malop")]
    public int Malop { get; set; }

    [Key]
    [Column("masinhvien")]
    public int Masinhvien { get; set; }

    [Column("ngaydangky")]
    public DateOnly Ngaydangky { get; set; }

    [Column("trangthai")]
    [StringLength(20)]
    public string Trangthai { get; set; } = null!;

    [ForeignKey("Malop")]
    [InverseProperty("DangKies")]
    public virtual LopHoc MalopNavigation { get; set; } = null!;

    [ForeignKey("Masinhvien")]
    [InverseProperty("DangKies")]
    public virtual SinhVien MasinhvienNavigation { get; set; } = null!;
}
