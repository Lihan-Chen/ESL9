using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "SUBJNO")]
[Table("ESL_SUBJECTS")]
[Index("FACILNO", "FACILTYPE", "SUBJNAME", Name = "ESL_SUBJECTS_UNQ", IsUnique = true)]
public partial class ESL_SUBJECT
{
    [Key]
    [Precision(2)]
    public byte FACILNO { get; set; }

    [Key]
    [Precision(3)]
    public byte SUBJNO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string SUBJNAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string FACILTYPE { get; set; } = null!;

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
