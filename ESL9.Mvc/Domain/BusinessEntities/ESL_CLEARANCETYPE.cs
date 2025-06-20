using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_CLEARANCETYPES")]
public partial class ESL_CLEARANCETYPE
{
    [Key]
    [Precision(2)]
    public byte CLEARANCETYPENO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string CLEARANCETYPENAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string CLEARANCETYPEABBR { get; set; } = null!;

    [Precision(2)]
    public byte SORTNO { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
