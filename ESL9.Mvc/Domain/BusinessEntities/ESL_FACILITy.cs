using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_FACILITIES")]
[Index("FACILNO", Name = "ESL_FACILITIES_PK", IsUnique = true)]
public partial class ESL_FACILITY
{
    [Precision(3)]
    public byte FACILNO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string FACILNAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string FACILABBR { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string FACILTYPE { get; set; } = null!;

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

    [StringLength(15)]
    [Unicode(false)]
    public string? DISABLE { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? VISIBLETO { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? FACILFULLNAME { get; set; }
}
