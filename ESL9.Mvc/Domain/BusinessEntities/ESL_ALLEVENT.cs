using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "LOGTYPENO", "EVENTID", "EVENTID_REVNO")]
[Table("ESL_ALLEVENTS")]
[Index("UPDATEDATE", Name = "UPDATEDATE")]
public partial class ESL_ALLEVENT
{
    [Key]
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Key]
    [Precision(2)]
    public byte LOGTYPENO { get; set; }

    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [Key]
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
    public string? MODIFYFLAG { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? OPERATORTYPE { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string UPDATEDBY { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public DateTime UPDATEDATE { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CLEARANCEID { get; set; }
}
