using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_LOGSTATUS")]
public partial class ESL_LOGSTATUS
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal LOGSTATUSNO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string LOGSTATUS { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? NOTES { get; set; }
}
