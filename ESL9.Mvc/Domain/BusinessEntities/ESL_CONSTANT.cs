using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_CONSTANTS")]
[Index("FACILNO", "CONSTANTNAME", "STARTDATE", Name = "ESL_CONSTANTS_PK", IsUnique = true)]
public partial class ESL_CONSTANT
{
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime STARTDATE { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CONSTANTNAME { get; set; } = null!;

    [Column(TypeName = "NUMBER")]
    public decimal? VALUE { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? ENDDATE { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
