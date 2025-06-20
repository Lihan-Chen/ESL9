using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

/// <summary>
/// Accumulated data from all profiler runs
/// </summary>
[PrimaryKey("RUNID", "UNIT_NUMBER", "LINE_")]
[Table("PLSQL_PROFILER_DATA")]
public partial class PLSQL_PROFILER_DATum
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal RUNID { get; set; }

    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal UNIT_NUMBER { get; set; }

    [Key]
    [Column("LINE#", TypeName = "NUMBER")]
    public decimal LINE_ { get; set; }

    [Unicode(false)]
    public string? TEXT { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? TOTAL_OCCUR { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? TOTAL_TIME { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? MIN_TIME { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? MAX_TIME { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SPARE1 { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SPARE2 { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SPARE3 { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SPARE4 { get; set; }

    [ForeignKey("RUNID, UNIT_NUMBER")]
    [InverseProperty("PLSQL_PROFILER_DATa")]
    public virtual PLSQL_PROFILER_UNIT PLSQL_PROFILER_UNIT { get; set; } = null!;
}
