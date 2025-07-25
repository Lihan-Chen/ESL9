﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "LOGTYPENO", "EVENTID", "EVENTID_REVNO")]
[Table("ESL_EOS")]
public partial class ESL_EOS
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

    [Precision(7)]
    public int OPERATORID { get; set; }

    [Precision(7)]
    public int? CREATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? CREATEDDATE { get; set; }

    [Precision(7)]
    public int? REPORTEDBY { get; set; }

    [Precision(7)]
    public int? REPORTEDTO { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? REPORTEDDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? REPORTEDTIME { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    public string EQUIPMENTINVOLVED { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string LOCATION { get; set; } = null!;

    [Precision(7)]
    public int? RELEASEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? RELEASEDDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? RELEASEDTIME { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RELEASETYPE { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TAGSINSTALLED { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TAGSREMOVED { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MODIFYFLAG { get; set; }

    [Precision(7)]
    public int? MODIFIEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? MODIFIEDDATE { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NOTIFIEDFACIL { get; set; }

    [Precision(7)]
    public int? NOTIFIEDPERSON { get; set; }

    [Precision(2)]
    public byte? SHIFTNO { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string YR { get; set; } = null!;

    [Precision(4)]
    public byte SEQNO { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string UPDATEDBY { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public DateTime UPDATEDATE { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? WORKORDERS { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? RELATEDTO { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? OPERATORTYPE { get; set; }
}
