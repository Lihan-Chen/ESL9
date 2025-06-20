using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_UNITS")]
public partial class ESL_UNIT
{
    [Column(TypeName = "NUMBER")]
    public decimal UNITNO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UNITNAME { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? UNITDESC { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? UPDATEBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
