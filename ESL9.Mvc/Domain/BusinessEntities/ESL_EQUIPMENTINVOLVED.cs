using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "EQUIPNO")]
[Table("ESL_EQUIPMENTINVOLVED")]
[Index("FACILNO", "FACILTYPE", "EQUIPNAME", Name = "ESL_EQUIPMENTINVOLVED_UNQ", IsUnique = true)]
public partial class ESL_EQUIPMENTINVOLVED
{
    [Key]
    [Precision(3)]
    public byte FACILNO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string FACILTYPE { get; set; } = null!;

    [Key]
    [Precision(3)]
    public byte EQUIPNO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EQUIPNAME { get; set; } = null!;

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DISABLE { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
