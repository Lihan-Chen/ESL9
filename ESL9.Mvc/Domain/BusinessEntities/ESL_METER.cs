using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "METERID")]
[Table("ESL_METERS")]
public partial class ESL_METER
{
    [Key]
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string METERID { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? METERTYPE { get; set; }

    [Precision(2)]
    public byte? SORTNO { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DISABLE { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
