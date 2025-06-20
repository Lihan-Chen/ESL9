using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILTYPE", "ZONENO")]
[Table("ESL_CLEARANCEZONES")]
public partial class ESL_CLEARANCEZONE
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string FACILTYPE { get; set; } = null!;

    [Key]
    [Precision(3)]
    public byte ZONENO { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ZONEDESCRIPTION { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DISABLE { get; set; }

    [Precision(2)]
    public byte? SORTNO { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }

    [Precision(3)]
    public byte? FACILNO { get; set; }
}
