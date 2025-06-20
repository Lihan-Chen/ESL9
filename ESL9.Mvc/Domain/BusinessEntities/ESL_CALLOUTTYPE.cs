using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_CALLOUTTYPES")]
public partial class ESL_CALLOUTTYPE
{
    [Key]
    [Column(TypeName = "NUMBER(38)")]
    public decimal CALLOUTTYPENO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CALLOUTTYPENAME { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
