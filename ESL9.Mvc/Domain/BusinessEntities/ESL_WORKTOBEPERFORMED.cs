using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILTYPE", "WORKNO")]
[Table("ESL_WORKTOBEPERFORMED")]
public partial class ESL_WORKTOBEPERFORMED
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string FACILTYPE { get; set; } = null!;

    [Key]
    [Precision(3)]
    public byte WORKNO { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string WORKDESCRIPTION { get; set; } = null!;

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [Precision(2)]
    public byte? SORTNO { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DISABLE { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
