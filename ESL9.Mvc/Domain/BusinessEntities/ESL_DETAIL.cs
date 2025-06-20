using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_DETAILS")]
[Index("FACILNO", "DETAILSNO", Name = "ESL_DETAILS_PK", IsUnique = true)]
public partial class ESL_DETAIL
{
    [Precision(3)]
    public byte FACILNO { get; set; }

    [Precision(3)]
    public byte DETAILSNO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string DETAILSNAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string FACILTYPE { get; set; } = null!;

    [Precision(2)]
    public byte? SORTNO { get; set; }

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

    [Precision(2)]
    public byte? SUBJNO { get; set; }
}
