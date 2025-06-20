using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
public partial class ESL_USER_INFO_VW
{
    [StringLength(11)]
    [Unicode(false)]
    public string EMPLID { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string FULL_NAME { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string FIRST_NAME { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string LAST_NAME { get; set; } = null!;

    [StringLength(24)]
    [Unicode(false)]
    public string WORK_PHONE { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string JOBTITLE { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string DEPTNAME { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MAIL_DROP { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_DIVISION_DESC { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_BRANCH_DESC { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_SECTION_DESC { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_UNIT_DESC { get; set; } = null!;

    [StringLength(41)]
    [Unicode(false)]
    public string? INTERNET_ID { get; set; }
}
