using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

/// <summary>
/// Run-specific information for the PL/SQL profiler
/// </summary>
[Table("PLSQL_PROFILER_RUNS")]
public partial class PLSQL_PROFILER_RUN
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal RUNID { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? RELATED_RUN { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? RUN_OWNER { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? RUN_PROC { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? RUN_DATE { get; set; }

    [StringLength(2047)]
    [Unicode(false)]
    public string? RUN_COMMENT { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? RUN_TOTAL_TIME { get; set; }

    [StringLength(2047)]
    [Unicode(false)]
    public string? RUN_SYSTEM_INFO { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? RUN_COMMENT1 { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? SPARE1 { get; set; }

    [InverseProperty("RUN")]
    public virtual ICollection<PLSQL_PROFILER_UNIT> PLSQL_PROFILER_UNITs { get; set; } = new List<PLSQL_PROFILER_UNIT>();
}
