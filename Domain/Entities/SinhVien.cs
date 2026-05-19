using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Domain.Entities;

[Table("SinhVien")]
public partial class SinhVien
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("tensv")]
    [StringLength(30)]
    public string Tensv { get; set; } = null!;

    [Column("mssv")]
    [StringLength(10)]
    [Unicode(false)]
    public string Mssv { get; set; } = null!;

    [InverseProperty("MasinhvienNavigation")]
    public virtual ICollection<DangKy> DangKies { get; set; } = new List<DangKy>();
}
