using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Domain.Entities;

[Table("LopHoc")]
public partial class LopHoc
{
    [Key]
    [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    [Column("tenlop")]
    [StringLength(30)]
    public string Tenlop { get; set; } = null!;

    [Column("sophong")]
    [StringLength(10)]
    public string Sophong { get; set; } = null!;

    [InverseProperty("MalopNavigation")]
    public virtual ICollection<DangKy> DangKies { get; set; } = new List<DangKy>();
}
