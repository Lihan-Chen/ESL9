using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_RPT_MISC")]
public partial class ESL_RPT_MISC
{
    [Precision(2)]
    public byte? FACILNO { get; set; }

    [Precision(2)]
    public byte? SERVERFACILNO { get; set; }

    [Precision(2)]
    public byte? LOGTYPENO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? EVENTID { get; set; }

    [Precision(2)]
    public byte? EVENTID_REVNO { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? LOGTYPE_SPECIFIC { get; set; }
}
