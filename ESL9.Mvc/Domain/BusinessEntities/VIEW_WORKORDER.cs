using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class VIEW_WORKORDER
{
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Precision(2)]
    public byte LOGTYPENO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string WO_NO { get; set; } = null!;

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
