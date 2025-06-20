using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class ESL_EMPLOYEES_WSO_P
{
    [StringLength(11)]
    [Unicode(false)]
    public string? EMPLOYEENO { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? FIRSTNAME { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LASTNAME { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? COMPANY { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LOCATION { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? GROUPNAME { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UNIT { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? TEAM { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? JOBTITLE { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? UPDATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? UPDATEDATE { get; set; }
}
