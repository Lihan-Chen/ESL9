using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_LOGTABLENAMES")]
public partial class ESL_LOGTABLENAME
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal LOGTYPENO { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LOGTABLENAME { get; set; }
}
