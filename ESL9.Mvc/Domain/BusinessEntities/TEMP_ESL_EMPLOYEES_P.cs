using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.Domain.BusinessEntities;

[Keyless]
[Table("TEMP_ESL_EMPLOYEES_PS")]
public partial class TEMP_ESL_EMPLOYEES_P
{
    [StringLength(1)]
    [Unicode(false)]
    public string? DUMMY_FIELD { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? EMPLID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NAME { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? FIRST_NAME { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LAST_NAME { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string? NAME_PREFIX { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PREFERRED_NAME { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? POSTAL { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? ORIG_HIRE_DT { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? HIRE_DT { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? REHIRE_DT { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? SERVICE_DT { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? REPORTS_TO { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? SUPERVISOR_ID { get; set; }

    [StringLength(24)]
    [Unicode(false)]
    public string? WORK_PHONE { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DEPTID { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? JOBCODE { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? POSITION_NBR { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? EMPL_CLASS { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LOCATION { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? REG_TEMP { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? FULL_PART_TIME { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string? SAL_ADMIN_PLAN { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? GRADE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? JOBTITLE { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? JOBTITLE_ABBRV { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DEPTNAME { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DEPTNAME_ABBRV { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? ASOFDATE { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MAIL_DROP { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? ACCT_CD { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? M_CONFLICT_INTRST { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? COUNTY { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? M_ETS_TIMEKEEPER { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? M_ETS_TIMEKPR_GRP { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? M_REVIEW_CYCLE { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? M_UNIT_COUNCIL { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? M_UNIT_GROUP { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? M_WORK_SCHEDULE { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? M_DIVISION { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? M_DIVISION_DESC { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? M_BRANCH { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? M_BRANCH_DESC { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? M_SECTION { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? M_SECTION_DESC { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? M_UNIT { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? M_UNIT_DESC { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? TEMP_FLD { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? TEMP_FLD2 { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? TEMP_FLD3 { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? TEMP_FLD4 { get; set; }

    [StringLength(41)]
    [Unicode(false)]
    public string? EMAIL_ADDR { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? PER_ORG { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? POI_TYPE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DESCR { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? UNION_CD { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DESCR_POSITION { get; set; }
}
