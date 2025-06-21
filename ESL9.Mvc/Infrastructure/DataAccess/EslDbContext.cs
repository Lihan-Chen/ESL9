using System;
using System.Collections.Generic;
using ESL9.Mvc.Domain.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Infrastructure.DataAccess;

public partial class EslDbContext : DbContext
{
    public EslDbContext()
    {
    }

    public EslDbContext(DbContextOptions<EslDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ESL_ALLEVENT> AllEvents { get; set; }

    public virtual DbSet<ESL_ALLSCADAUSERS_ROLE> UserRoles { get; set; }

    public virtual DbSet<ESL_CALLOUTTYPE> CalloutTypes { get; set; }

    public virtual DbSet<ESL_CLEARANCEISSUE> ClearanceIssues { get; set; }

    public virtual DbSet<ESL_CLEARANCETYPE> ClearanceTypes { get; set; }

    public virtual DbSet<ESL_CLEARANCEZONE> ClearanceZones { get; set; }

    public virtual DbSet<ESL_CONSTANT> EslConstants { get; set; }

    public virtual DbSet<ESL_DETAIL> Details { get; set; }

    public virtual DbSet<ESL_EMPLOYEE> Employees { get; set; }

    //public virtual DbSet<ESL_EMPLOYEES_P> ESL_EMPLOYEES_Ps { get; set; }

    public virtual DbSet<ESL_EO> EOSLogs { get; set; }

    public virtual DbSet<ESL_EQUIPMENTINVOLVED> Equipment { get; set; }

    public virtual DbSet<ESL_FACILITY> Facilities { get; set; }

    public virtual DbSet<ESL_FLOWCHANGE> FlowChangeLog { get; set; }

    public virtual DbSet<ESL_GENERAL> GeneralLog { get; set; }

    public virtual DbSet<ESL_LOGSTATUS> LogStatus { get; set; }

    public virtual DbSet<ESL_LOGTABLENAME> LogTables { get; set; }

    public virtual DbSet<ESL_LOGTYPE> LogTypes { get; set; }

    public virtual DbSet<ESL_METER> Meters { get; set; }

    public virtual DbSet<ESL_PLANTSHIFT> PlantShits { get; set; }

    public virtual DbSet<ESL_RELATEDTO> RelatedEvents { get; set; }

    public virtual DbSet<ESL_RPT_ALLEVENT> RptAllEvents { get; set; }

    public virtual DbSet<ESL_RPT_MISC> RptMiscs { get; set; }

    public virtual DbSet<ESL_SCADAROLE> ScadaRoles { get; set; }

    public virtual DbSet<ESL_SCADA_LOG> ScanLogs { get; set; }

    public virtual DbSet<ESL_SCANDOC> ScanDocs { get; set; }

    public virtual DbSet<ESL_SCANLOB> ScanLobs { get; set; }

    public virtual DbSet<ESL_SOC> SOCLogs { get; set; }

    public virtual DbSet<ESL_SUBJECT> Subjects { get; set; }

    public virtual DbSet<ESL_UNIT> Units { get; set; }

    public virtual DbSet<ESL_USER> Users { get; set; }

    //public virtual DbSet<ESL_USER_INFO_VW> ESL_USER_INFO_VWs { get; set; }

    //public virtual DbSet<ESL_WEBTRANSACTION> ESL_WEBTRANSACTIONs { get; set; }

    public virtual DbSet<ESL_WORKORDER> WorkOrders { get; set; }

    public virtual DbSet<ESL_WORKTOBEPERFORMED> WorkToBePerformed { get; set; }

    //public virtual DbSet<PLSQL_PROFILER_DATum> PLSQL_PROFILER_DATAs { get; set; }

    //public virtual DbSet<PLSQL_PROFILER_RUN> PLSQL_PROFILER_RUNs { get; set; }

    //public virtual DbSet<PLSQL_PROFILER_UNIT> PLSQL_PROFILER_UNITs { get; set; }

    //public virtual DbSet<QUEST_SL_TEMP_EXPLAIN1> QUEST_SL_TEMP_EXPLAIN1s { get; set; }

    //public virtual DbSet<TEMP_ESL_EMPLOYEES_P> TEMP_ESL_EMPLOYEES_Ps { get; set; }

    //public virtual DbSet<TOAD_PLAN_SQL> TOAD_PLAN_SQLs { get; set; }

    //public virtual DbSet<TOAD_PLAN_TABLE> TOAD_PLAN_TABLEs { get; set; }

    public virtual DbSet<VIEW_ALLEVENTS_CURRENT> Current_AllEvents { get; set; }

    //public virtual DbSet<VIEW_ALLEVENTS_FACILNO> VIEW_ALLEVENTS_FACILNOs { get; set; }

    //public virtual DbSet<VIEW_ALLEVENTS_LOGTYPE> VIEW_ALLEVENTS_LOGTYPEs { get; set; }

    public virtual DbSet<VIEW_ALLEVENTS_RELATEDTO> Related_AllEvents { get; set; }

    public virtual DbSet<VIEW_ALLEVENTS_SEARCH> Searched_AllEvents { get; set; }

    public virtual DbSet<VIEW_CLEARANCEISSUE> ClearanceIssue_Events { get; set; }

    public virtual DbSet<VIEW_CLEARANCEISSUES_CURRENT> Current_ClearanceIssuesEvents { get; set; }

    //public virtual DbSet<VIEW_CLEARANCETYPE> ClearanceTypes { get; set; }

    public virtual DbSet<VIEW_CLEARANCE_ALL> All_Clearances { get; set; }

    public virtual DbSet<VIEW_CLEARANCE_OUTSTANDING> OutStanding_Clearances { get; set; }

    public virtual DbSet<VIEW_EOS_ALL> All_EOS { get; set; }

    public virtual DbSet<VIEW_EOS_CURRENT> Current_EOS { get; set; }

    public virtual DbSet<VIEW_EOS_OUTSTANDING> Outstanding_EOS { get; set; }

    public virtual DbSet<VIEW_FLOWCHANGES_CURRENT> Current_FlowChanges { get; set; }

    public virtual DbSet<VIEW_FLOWCHANGE_ALL> All_FlowChanges { get; set; }

    public virtual DbSet<VIEW_FLOWCHANGE_PRESCHED> PreSched_FlowChanges { get; set; }

    public virtual DbSet<VIEW_GENERAL_ALL> All_General { get; set; }

    public virtual DbSet<VIEW_GENERAL_CURRENT> Current_General { get; set; }

    public virtual DbSet<VIEW_GENERAL_OUTSTANDING> Outstanding_General { get; set; }

    // All Prescheduled Flow Changes where event is due within the next 30 minutes
    public virtual DbSet<VIEW_REALTIME> RealTime_FlowChanges { get; set; }

    // 
    public virtual DbSet<VIEW_SEARCH_ALLEVENT> Search_AllEvents { get; set; }

    public virtual DbSet<VIEW_SOC_ALL> All_SOC { get; set; }

    public virtual DbSet<VIEW_SOC_CURRENT> Current_SOC { get; set; }

    public virtual DbSet<VIEW_SOC_OUTSTANDING> Outstanding_SOC { get; set; }

    // Deprecated :The view for selecting all worker records, not needed anymore
    //public virtual DbSet<VIEW_WORKORDER> VIEW_WORKORDERs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=odev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ESL")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<ESL_ALLEVENT>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.LOGTYPENO, e.EVENTID, e.EVENTID_REVNO }).HasName("ESL_ALLEVENTS_PK");
        });

        modelBuilder.Entity<ESL_CALLOUTTYPE>(entity =>
        {
            entity.HasKey(e => e.CALLOUTTYPENO).HasName("ESL_CALLOUTTYPES_PK");
        });

        modelBuilder.Entity<ESL_CLEARANCETYPE>(entity =>
        {
            entity.HasKey(e => e.CLEARANCETYPENO).HasName("ESL_CLEARANCETYPES_PK");
        });

        modelBuilder.Entity<ESL_CLEARANCEZONE>(entity =>
        {
            entity.HasKey(e => new { e.FACILTYPE, e.ZONENO }).HasName("ESL_CLEARANCEZONES_PK");
        });

        modelBuilder.Entity<ESL_DBLINK_XESL>(entity =>
        {
            entity.HasKey(e => e.FACILNO).HasName("ESL_DBLINK_XESL_PK");
        });

        modelBuilder.Entity<ESL_EMPLOYEE>(entity =>
        {
            entity.HasKey(e => e.EMPLOYEENO).HasName("EMPLOYEES_PK");

            entity.Property(e => e.EMPLOYEENO).ValueGeneratedNever();
        });

        modelBuilder.Entity<ESL_EMPLOYEES_P>(entity =>
        {
            entity.ToView("ESL_EMPLOYEES_PS");

            entity.Property(e => e.M_CONFLICT_INTRST).IsFixedLength();
            entity.Property(e => e.TEMP_FLD).IsFixedLength();
            entity.Property(e => e.TEMP_FLD2).IsFixedLength();
            entity.Property(e => e.TEMP_FLD3).IsFixedLength();
            entity.Property(e => e.TEMP_FLD4).IsFixedLength();
        });

        modelBuilder.Entity<ESL_EMPLOYEES_WSO_P>(entity =>
        {
            entity.ToView("ESL_EMPLOYEES_WSO_PS");

            entity.Property(e => e.COMPANY).IsFixedLength();
        });

        modelBuilder.Entity<ESL_EO>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.LOGTYPENO, e.EVENTID, e.EVENTID_REVNO }).HasName("ESL_EOS_PK");
        });

        modelBuilder.Entity<ESL_EQUIPMENTINVOLVED>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.EQUIPNO }).HasName("ESL_EQUIPMENTINVOLVED_PK");
        });

        modelBuilder.Entity<ESL_FLOWCHANGE>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.LOGTYPENO, e.EVENTID, e.EVENTID_REVNO }).HasName("ESL_FLOWCHANGES_PK");
        });

        modelBuilder.Entity<ESL_GENERAL>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.LOGTYPENO, e.EVENTID, e.EVENTID_REVNO }).HasName("ESL_GENERAL_PK");
        });

        modelBuilder.Entity<ESL_LOGSTATUS>(entity =>
        {
            entity.HasKey(e => e.LOGSTATUSNO).HasName("ESL_LOGSTATUS_PK");
        });

        modelBuilder.Entity<ESL_LOGTABLENAME>(entity =>
        {
            entity.HasKey(e => e.LOGTYPENO).HasName("ESL_LOGNAMES_PK");
        });

        modelBuilder.Entity<ESL_LOGTYPE>(entity =>
        {
            entity.HasKey(e => e.LOGTYPENO).HasName("ESL_LOGTYPES_PK");
        });

        modelBuilder.Entity<ESL_METER>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.METERID }).HasName("ESL_METERS_PK");
        });

        modelBuilder.Entity<ESL_PLANTSHIFT>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.SHIFTNO }).HasName("PLANTSHIFT_PK");
        });

        modelBuilder.Entity<ESL_SCADAROLE>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.GRANTEE, e.ROLE }).HasName("ESL_SCADAROLES_TEST_PK");
        });

        modelBuilder.Entity<ESL_SCANLOB>(entity =>
        {
            entity.HasKey(e => e.SCANSEQNO).HasName("ESL_SCANLOBS_PK");

            entity.Property(e => e.SCANBLOB).HasDefaultValueSql("EMPTY_BLOB()");
        });

        modelBuilder.Entity<ESL_SOC>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.LOGTYPENO, e.EVENTID, e.EVENTID_REVNO }).HasName("ESL_SOC_PK");
        });

        modelBuilder.Entity<ESL_SUBJECT>(entity =>
        {
            entity.HasKey(e => new { e.FACILNO, e.SUBJNO }).HasName("ESL_SUBJECTS_PK");
        });

        modelBuilder.Entity<ESL_USER_INFO_VW>(entity =>
        {
            entity.ToView("ESL_USER_INFO_VW");
        });

        modelBuilder.Entity<ESL_WEBTRANSACTION>(entity =>
        {
            entity.HasKey(e => e.TRANSACTIONID).HasName("ESL_WEBTRANSACTIONS_PK");

            entity.Property(e => e.UPDATEDATE).HasDefaultValueSql("sysdate ");
        });

        modelBuilder.Entity<ESL_WORKTOBEPERFORMED>(entity =>
        {
            entity.HasKey(e => new { e.FACILTYPE, e.WORKNO }).HasName("WORKTOBEPERFORMED_PK");
        });

        modelBuilder.Entity<LOGTYPE>(entity =>
        {
            entity.HasKey(e => e.LOGTYPENO).HasName("LOGTYPES_PK");
        });

        modelBuilder.Entity<PLSQL_PROFILER_DATum>(entity =>
        {
            entity.HasKey(e => new { e.RUNID, e.UNIT_NUMBER, e.LINE_ }).HasName("SYS_C008041");

            entity.ToTable("PLSQL_PROFILER_DATA", tb => tb.HasComment("Accumulated data from all profiler runs"));

            entity.HasOne(d => d.PLSQL_PROFILER_UNIT).WithMany(p => p.PLSQL_PROFILER_DATa).HasConstraintName("SYS_C008061");
        });

        modelBuilder.Entity<PLSQL_PROFILER_RUN>(entity =>
        {
            entity.HasKey(e => e.RUNID).HasName("SYS_C008042");

            entity.ToTable("PLSQL_PROFILER_RUNS", tb => tb.HasComment("Run-specific information for the PL/SQL profiler"));
        });

        modelBuilder.Entity<PLSQL_PROFILER_UNIT>(entity =>
        {
            entity.HasKey(e => new { e.RUNID, e.UNIT_NUMBER }).HasName("SYS_C008043");

            entity.ToTable("PLSQL_PROFILER_UNITS", tb => tb.HasComment("Information about each library unit in a run"));

            entity.Property(e => e.TOTAL_TIME).HasDefaultValueSql("0 ");

            entity.HasOne(d => d.RUN).WithMany(p => p.PLSQL_PROFILER_UNITs).HasConstraintName("SYS_C008062");
        });

        modelBuilder.Entity<TEMP_ESL_EMPLOYEES_P>(entity =>
        {
            entity.Property(e => e.M_CONFLICT_INTRST).IsFixedLength();
            entity.Property(e => e.TEMP_FLD).IsFixedLength();
            entity.Property(e => e.TEMP_FLD2).IsFixedLength();
            entity.Property(e => e.TEMP_FLD3).IsFixedLength();
            entity.Property(e => e.TEMP_FLD4).IsFixedLength();
        });

        modelBuilder.Entity<VIEW_ALLEVENTS_CURRENT>(entity =>
        {
            entity.ToView("VIEW_ALLEVENTS_CURRENT");
        });

        modelBuilder.Entity<VIEW_ALLEVENTS_FACILNO>(entity =>
        {
            entity.ToView("VIEW_ALLEVENTS_FACILNOS");
        });

        modelBuilder.Entity<VIEW_ALLEVENTS_LOGTYPE>(entity =>
        {
            entity.ToView("VIEW_ALLEVENTS_LOGTYPES");
        });

        modelBuilder.Entity<VIEW_ALLEVENTS_RELATEDTO>(entity =>
        {
            entity.ToView("VIEW_ALLEVENTS_RELATEDTO");
        });

        modelBuilder.Entity<VIEW_ALLEVENTS_SEARCH>(entity =>
        {
            entity.ToView("VIEW_ALLEVENTS_SEARCH");
        });

        modelBuilder.Entity<VIEW_CLEARANCEISSUE>(entity =>
        {
            entity.ToView("VIEW_CLEARANCEISSUES");
        });

        modelBuilder.Entity<VIEW_CLEARANCEISSUES_CURRENT>(entity =>
        {
            entity.ToView("VIEW_CLEARANCEISSUES_CURRENT");
        });

        modelBuilder.Entity<VIEW_CLEARANCETYPE>(entity =>
        {
            entity.ToView("VIEW_CLEARANCETYPES");
        });

        modelBuilder.Entity<VIEW_CLEARANCE_ALL>(entity =>
        {
            entity.ToView("VIEW_CLEARANCE_ALL");
        });

        modelBuilder.Entity<VIEW_CLEARANCE_OUTSTANDING>(entity =>
        {
            entity.ToView("VIEW_CLEARANCE_OUTSTANDING");
        });

        modelBuilder.Entity<VIEW_EOS_ALL>(entity =>
        {
            entity.ToView("VIEW_EOS_ALL");
        });

        modelBuilder.Entity<VIEW_EOS_CURRENT>(entity =>
        {
            entity.ToView("VIEW_EOS_CURRENT");
        });

        modelBuilder.Entity<VIEW_EOS_OUTSTANDING>(entity =>
        {
            entity.ToView("VIEW_EOS_OUTSTANDING");
        });

        modelBuilder.Entity<VIEW_FLOWCHANGES_CURRENT>(entity =>
        {
            entity.ToView("VIEW_FLOWCHANGES_CURRENT");
        });

        modelBuilder.Entity<VIEW_FLOWCHANGE_ALL>(entity =>
        {
            entity.ToView("VIEW_FLOWCHANGE_ALL");
        });

        modelBuilder.Entity<VIEW_FLOWCHANGE_PRESCHED>(entity =>
        {
            entity.ToView("VIEW_FLOWCHANGE_PRESCHED");
        });

        modelBuilder.Entity<VIEW_GENERAL_ALL>(entity =>
        {
            entity.ToView("VIEW_GENERAL_ALL");
        });

        modelBuilder.Entity<VIEW_GENERAL_CURRENT>(entity =>
        {
            entity.ToView("VIEW_GENERAL_CURRENT");
        });

        modelBuilder.Entity<VIEW_GENERAL_OUTSTANDING>(entity =>
        {
            entity.ToView("VIEW_GENERAL_OUTSTANDING");
        });

        modelBuilder.Entity<VIEW_REALTIME>(entity =>
        {
            entity.ToView("VIEW_REALTIME");
        });

        modelBuilder.Entity<VIEW_SEARCH_ALLEVENT>(entity =>
        {
            entity.ToView("VIEW_SEARCH_ALLEVENTS");
        });

        modelBuilder.Entity<VIEW_SOC_ALL>(entity =>
        {
            entity.ToView("VIEW_SOC_ALL");
        });

        modelBuilder.Entity<VIEW_SOC_CURRENT>(entity =>
        {
            entity.ToView("VIEW_SOC_CURRENT");
        });

        modelBuilder.Entity<VIEW_SOC_OUTSTANDING>(entity =>
        {
            entity.ToView("VIEW_SOC_OUTSTANDING");
        });

        modelBuilder.Entity<VIEW_WORKORDER>(entity =>
        {
            entity.ToView("VIEW_WORKORDERS");
        });
        modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
