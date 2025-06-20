using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("TOAD_PLAN_TABLE")]
[Index("STATEMENT_ID", Name = "TPTBL_IDX")]
public partial class TOAD_PLAN_TABLE
{
    [StringLength(32)]
    [Unicode(false)]
    public string? STATEMENT_ID { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? TIMESTAMP { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? REMARKS { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? OPERATION { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? OPTIONS { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? OBJECT_NODE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? OBJECT_OWNER { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? OBJECT_NAME { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? OBJECT_INSTANCE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? OBJECT_TYPE { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? SEARCH_COLUMNS { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? ID { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? COST { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? PARENT_ID { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? POSITION { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? CARDINALITY { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? OPTIMIZER { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? BYTES { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? OTHER_TAG { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? PARTITION_ID { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PARTITION_START { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PARTITION_STOP { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DISTRIBUTION { get; set; }

    [Column(TypeName = "LONG")]
    public string? OTHER { get; set; }
}
