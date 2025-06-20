using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("ESL_ALLSCADAUSERS_ROLE")]
[Index("FACILNO", "USERID", Name = "ESL_ALLSCADAUSERS_USERID_IDX")]
public partial class ESL_ALLSCADAUSERS_ROLE
{
    [Column(TypeName = "NUMBER(38)")]
    public decimal? FACILNO { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? USERID { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? ROLE { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? ADMIN_OPTION { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? DEFAULT_ROLE { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }
}
