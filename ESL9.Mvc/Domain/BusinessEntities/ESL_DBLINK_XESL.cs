using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_DBLINK_XESL")]
public partial class ESL_DBLINK_XESL
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal FACILNO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? DBLINK { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DBLINK_ACCT { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DBLINK_SCADA { get; set; }
}
