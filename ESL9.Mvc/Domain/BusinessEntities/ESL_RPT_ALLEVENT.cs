using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_RPT_ALLEVENTS")]
public partial class ESL_RPT_ALLEVENT
{
    [StringLength(40)]
    [Unicode(false)]
    public string? FACILNAME { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LOGTYPENAME { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? EVENTID { get; set; }

    [Precision(2)]
    public byte? EVENTID_REVNO { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? EVENTDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? EVENTTIME { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    public string? SUBJECT { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? DETAILS { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBYNAME { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }

    [Precision(2)]
    public byte? FACILNO { get; set; }

    [Precision(2)]
    public byte? LOGTYPENO { get; set; }
}
