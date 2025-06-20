using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[PrimaryKey("FACILNO", "GRANTEE", "ROLE")]
[Table("ESL_SCADAROLES")]
[Index("FACILNO", "GRANTEE", Name = "ESL_SCADAROLE_USERID_IDX")]
public partial class ESL_SCADAROLE
{
    [Key]
    [Column(TypeName = "NUMBER(38)")]
    public decimal FACILNO { get; set; }

    [Key]
    [StringLength(30)]
    [Unicode(false)]
    public string GRANTEE { get; set; } = null!;

    [Key]
    [StringLength(30)]
    [Unicode(false)]
    public string ROLE { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string? ADMIN_OPTION { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? DEFAULT_ROLE { get; set; }
}
