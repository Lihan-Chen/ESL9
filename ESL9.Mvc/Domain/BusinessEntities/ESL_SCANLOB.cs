using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_SCANLOBS")]
[Index("FACILNO", "LOGTYPENO", "EVENTID", "SCANNO", Name = "SCANLOB_DOC_IDX")]
public partial class ESL_SCANLOB
{
    [Key]
    [Column(TypeName = "NUMBER(38)")]
    public int SCANSEQNO { get; set; }

    [Precision(2)]
    public int FACILNO { get; set; }

    [Precision(2)]
    public int LOGTYPENO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [Precision(2)]
    public int SCANNO { get; set; }

    [Column(TypeName = "BLOB")]
    public byte[]? SCANBLOB { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SCANLOBTYPE { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SCANFILENAME { get; set; }
}
