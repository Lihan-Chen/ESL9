using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_SCADA_LOG")]
public partial class ESL_SCADA_LOG
{
    [Column(TypeName = "NUMBER")]
    public decimal? FACILNO { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? LOGTYPENO { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? EVENTID { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? EVENTID_REVNO { get; set; }

    [StringLength(600)]
    [Unicode(false)]
    public string? STATUS { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }

    [Precision(6)]
    public DateTime? LOG_STAMP { get; set; }
}
