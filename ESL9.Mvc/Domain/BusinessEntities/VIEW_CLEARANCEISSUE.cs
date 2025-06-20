using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class VIEW_CLEARANCEISSUE
{
    [Precision(2)]
    public byte FACILNO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string FACILNAME { get; set; } = null!;

    [Precision(2)]
    public byte LOGTYPENO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LOGTYPENAME { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [Precision(2)]
    public byte EVENTID_REVNO { get; set; }

    [Precision(7)]
    public int OPERATORID { get; set; }

    [StringLength(101)]
    [Unicode(false)]
    public string? OPERATOR { get; set; }

    [Precision(7)]
    public int? CREATEDBY { get; set; }

    [StringLength(101)]
    [Unicode(false)]
    public string? CREATOR { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? CREATEDDATE { get; set; }

    [Precision(7)]
    public int ISSUEDTO { get; set; }

    [Precision(7)]
    public int ISSUEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime ISSUEDDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string ISSUEDTIME { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? MODIFYFLAG { get; set; }

    [Precision(7)]
    public int? MODIFIEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? MODIFIEDDATE { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string YR { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string FACILABBR { get; set; } = null!;

    [Precision(4)]
    public byte SEQNO { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string CLEARANCETYPE { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string CLEARANCEZONE { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? LOCATION { get; set; }

    [StringLength(600)]
    [Unicode(false)]
    public string? WORKTOBEPERFORMED { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? EQUIPMENTINVOLVED { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? WORKORDERS { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? RELATEDTO { get; set; }

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

    [Precision(7)]
    public int? RELEASEDTO { get; set; }

    [Precision(7)]
    public int? RELEASEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? RELEASEDDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? RELEASEDTIME { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? RELEASETYPE { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? TAGSREMOVED { get; set; }

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
