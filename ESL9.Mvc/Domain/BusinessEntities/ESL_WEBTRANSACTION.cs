using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_WEBTRANSACTIONS")]
public partial class ESL_WEBTRANSACTION
{
    [Key]
    [Column(TypeName = "NUMBER(38)")]
    public decimal TRANSACTIONID { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal FACILNO { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal LOGTYPENO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [Column(TypeName = "NUMBER")]
    public decimal EVENTID_REVNO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MODIFYFLAG { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime UPDATEDATE { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ERRORMESSAGE { get; set; }

    [Precision(6)]
    public DateTime? TRANSACTIONTIMESTAMP { get; set; }
}
