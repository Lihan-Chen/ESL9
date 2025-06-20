using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_RELATEDTO")]
[Index("FACILNO", "LOGTYPENO", "EVENTID", "RELATEDTO_SUBJECT", Name = "ESL_RELATEDTO_PK", IsUnique = true)]
public partial class ESL_RELATEDTO
{
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Precision(2)]
    public byte LOGTYPENO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [StringLength(120)]
    [Unicode(false)]
    public string RELATEDTO_SUBJECT { get; set; } = null!;

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
