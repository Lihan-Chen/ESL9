using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Table("ESL_EMPLOYEES")]
public partial class ESL_EMPLOYEE
{
    [Key]
    [Precision(8)]
    public int EMPLOYEENO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LASTNAME { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FIRSTNAME { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? COMPANY { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? GROUPNAME { get; set; }

    [Precision(3)]
    public byte? FACILNO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? JOBTITLE { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DISABLE { get; set; }
}
