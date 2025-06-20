using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "SHIFTNO")]
[Table("ESL_PLANTSHIFTS")]
[Index("FACILNO", "SHIFTNO", "SHIFTSTART", "SHIFTEND", Name = "ESL_PLANTSHIFTS_UNQ", IsUnique = true)]
public partial class ESL_PLANTSHIFT
{
    [Key]
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Key]
    [Precision(2)]
    public byte SHIFTNO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SHIFTNAME { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string SHIFTSTART { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string SHIFTEND { get; set; } = null!;

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
