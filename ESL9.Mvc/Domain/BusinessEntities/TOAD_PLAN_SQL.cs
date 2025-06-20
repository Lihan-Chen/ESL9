using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("TOAD_PLAN_SQL")]
[Index("STATEMENT_ID", Name = "TPSQL_IDX", IsUnique = true)]
public partial class TOAD_PLAN_SQL
{
    [StringLength(30)]
    [Unicode(false)]
    public string? USERNAME { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? STATEMENT_ID { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? TIMESTAMP { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? STATEMENT { get; set; }
}
