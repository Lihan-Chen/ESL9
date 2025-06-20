using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

/// <summary>
/// Information about each library unit in a run
/// </summary>
[PrimaryKey("RUNID", "UNIT_NUMBER")]
[Table("PLSQL_PROFILER_UNITS")]
public partial class PLSQL_PROFILER_UNIT
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal RUNID { get; set; }

    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal UNIT_NUMBER { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UNIT_TYPE { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UNIT_OWNER { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UNIT_NAME { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UNIT_TIMESTAMP { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal TOTAL_TIME { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SPARE1 { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SPARE2 { get; set; }

    [InverseProperty("PLSQL_PROFILER_UNIT")]
    public virtual ICollection<PLSQL_PROFILER_DATum> PLSQL_PROFILER_DATa { get; set; } = new List<PLSQL_PROFILER_DATum>();

    [ForeignKey("RUNID")]
    [InverseProperty("PLSQL_PROFILER_UNITs")]
    public virtual PLSQL_PROFILER_RUN RUN { get; set; } = null!;
}
