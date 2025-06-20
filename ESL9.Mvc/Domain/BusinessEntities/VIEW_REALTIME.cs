using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class VIEW_REALTIME
{
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Precision(2)]
    public byte LOGTYPENO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [Precision(2)]
    public byte EVENTID_REVNO { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? EVENTDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? EVENTTIME { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? SUBJECT { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? DETAILS { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LOGTYPENAME { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string FACILNAME { get; set; } = null!;

    [StringLength(101)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [StringLength(19)]
    [Unicode(false)]
    public string? UPDATEDATE { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? OPERATORTYPE { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SCANDOCSNO { get; set; }
}
