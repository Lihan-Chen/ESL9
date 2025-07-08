using Microsoft.EntityFrameworkCore;
using Core.Models.BusinessEntities;

namespace Infrastructure.DataAccess;

public partial class EslDbContext : DbContext //, IEslDbContext
{
    public EslDbContext()
    {
    }

    public EslDbContext(DbContextOptions<EslDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllEvent> AllEvents { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    //public virtual DbSet<CalloutType> CalloutTypes { get; set; }

    public virtual DbSet<EslClearanceIssue> ClearanceIssueLog { get; set; }

    public virtual DbSet<ClearanceType> ClearanceTypes { get; set; }

    public virtual DbSet<ClearanceZone> ClearanceZones { get; set; }

    public virtual DbSet<EslConstant> EslConstants { get; set; }

    public virtual DbSet<EslDetail> Details { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EslEOS> EOSLog { get; set; }

    public virtual DbSet<EquipmentInvolved> Equipment { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<EslFlowchange> FlowChangeLog { get; set; }

    public virtual DbSet<EslGeneral> GeneralLog { get; set; }

    //public virtual DbSet<EslLogStatus> LogStatuses { get; set; }

    public virtual DbSet<LogType> LogTypes { get; set; }

    public virtual DbSet<EslMeter> Meters { get; set; }

    public virtual DbSet<PlantShift> PlantShifts { get; set; }

    public virtual DbSet<RelatedTo> RelatedEvents { get; set; }

    public virtual DbSet<RptAllEvent> RptAllEvents { get; set; }

    public virtual DbSet<RptMisc> RptMiscs { get; set; }

    public virtual DbSet<ScanDoc> EslScanDocs { get; set; }

    public virtual DbSet<ScanLob> EslScanLobs { get; set; }

    public virtual DbSet<EslSOC> SOCLog { get; set; }

    public virtual DbSet<EslSubject> Subjects { get; set; }

    public virtual DbSet<EslUnit> Units { get; set; }

    public virtual DbSet<WorkOrder> WorkOrders { get; set; }

    public virtual DbSet<WorkToBePerformed> WorkToBePerformeds { get; set; }

    ////#region Views
    ////public virtual DbSet<ViewAllEventsCurrent> ViewAllEventsCurrents { get; set; }

    ////public virtual DbSet<ViewAllEventsFacilNo> ViewAllEventsFacilNos { get; set; }

    ////public virtual DbSet<ViewAllEventsLogType> ViewAllEventsLogTypes { get; set; }

    ////public virtual DbSet<ViewAllEventsRelatedTo> ViewAllEventsRelatedTos { get; set; }

    ////public virtual DbSet<ViewAllEventsSearch> ViewAllEventsSearches { get; set; }

    ////public virtual DbSet<ViewClearanceAll> ViewClearanceAlls { get; set; }

    ////public virtual DbSet<ViewClearanceOutstanding> ViewClearanceOutstandings { get; set; }

    ////public virtual DbSet<ViewClearanceIssue> ViewClearanceIssues { get; set; }

    ////public virtual DbSet<ViewClearanceIssuesCurrent> ViewClearanceIssuesCurrents { get; set; }

    ////public virtual DbSet<ViewClearanceType> ViewClearanceTypes { get; set; }

    ////public virtual DbSet<ViewEOSAll> ViewEOSAlls { get; set; }

    ////public virtual DbSet<ViewEOSCurrent> ViewEOSCurrents { get; set; }

    ////public virtual DbSet<ViewEOSOutstanding> ViewEOSOutstandings { get; set; }

    ////public virtual DbSet<ViewFlowChangeAll> ViewFlowChangeAlls { get; set; }

    ////public virtual DbSet<ViewFlowChangePresched> ViewFlowChangePrescheds { get; set; }

    ////public virtual DbSet<ViewFlowChangesCurrent> ViewFlowChangesCurrents { get; set; }

    ////public virtual DbSet<ViewGeneralAll> ViewGeneralAlls { get; set; }

    ////public virtual DbSet<ViewGeneralCurrent> ViewGeneralCurrents { get; set; }

    ////public virtual DbSet<ViewGeneralOutstanding> ViewGeneralOutstandings { get; set; }

    ////public virtual DbSet<ViewRealTime> ViewRealTimes { get; set; }

    ////public virtual DbSet<ViewSearchAllEvent> ViewSearchAllEvents { get; set; }

    ////public virtual DbSet<ViewSOCAll> ViewSOCAlls { get; set; }

    ////public virtual DbSet<ViewSOCCurrent> ViewSOCCurrents { get; set; }

    ////public virtual DbSet<ViewSOCOutstanding> ViewSOCOutstandings { get; set; }

    ////public virtual DbSet<ViewWorkOrder> ViewWorkOrders { get; set; }

    ////#endregion Views

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=odev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ESL")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<AllEvent>(entity =>
        {
            entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_ALLEVENTS_PK");

            entity.ToTable("ESL_ALLEVENTS");

            entity.HasIndex(e => e.UpdateDate, "UPDATEDATE");

            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.ClearanceID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.ModifyFlag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_ALLSCADAUSERS_ROLE");

            entity.HasIndex(e => new { e.FacilNo, e.UserID }, "ESL_ALLSCADAUSERS_USERID_IDX");

            entity.Property(e => e.AdminOption)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ADMIN_OPTION");
            entity.Property(e => e.DefaultRole)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DEFAULT_ROLE");
            entity.Property(e => e.FacilNo)
                .HasColumnType("NUMBER")
                .HasColumnName("FACILNO");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ROLE");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.UserID)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USERID");
        });

        //modelBuilder.Entity<CalloutType>(entity =>
        //{
        //    entity.HasKey(e => e.CalloutTypeNo).HasName("ESL_CALLOUTTYPES_PK");

        //    entity.ToTable("ESL_CALLOUTTYPES");

        //    entity.Property(e => e.CalloutTypeNo)
        //        .HasColumnType("NUMBER(38)")
        //        .HasColumnName("CALLOUTTYPENO");
        //    entity.Property(e => e.CalloutTypeName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("CALLOUTTYPENAME");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        modelBuilder.Entity<EslClearanceIssue>(entity =>
        {
            entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_CLEARANCEISSUES_PK");

            entity.ToTable("ESL_CLEARANCEISSUES");

            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.ClearanceID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.ClearanceType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPE");
            entity.Property(e => e.ClearanceZone)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEZONE");
            entity.Property(e => e.CreatedBy)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.EquipmentInvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.IssuedBy)
                .HasPrecision(7)
                .HasColumnName("ISSUEDBY");
            entity.Property(e => e.IssuedDate)
                .HasColumnType("DATE")
                .HasColumnName("ISSUEDDATE");
            entity.Property(e => e.IssuedTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ISSUEDTIME");
            entity.Property(e => e.IssuedTo)
                .HasPrecision(7)
                .HasColumnName("ISSUEDTO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.ModifiedBy)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.ModifyFlag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.NotifiedFacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.NotifiedPerson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.OperatorID)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.RelatedTo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.ReleasedBy)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.ReleasedDate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.ReleasedTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.ReleasedTo)
                .HasPrecision(7)
                .HasColumnName("RELEASEDTO");
            entity.Property(e => e.ReleaseType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.SeqNo)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.ShiftNo)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.TagsRemoved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.WorkOrders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.WorkToBePerformed)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("WORKTOBEPERFORMED");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ClearanceType>(entity =>
        {
            entity.HasKey(e => e.ClearanceTypeNo).HasName("ESL_CLEARANCETYPES_PK");

            entity.ToTable("ESL_CLEARANCETYPES");

            entity.Property(e => e.ClearanceTypeNo)
                .HasPrecision(2)
                .HasColumnName("CLEARANCETYPENO");
            entity.Property(e => e.ClearanceTypeAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPEABBR");
            entity.Property(e => e.ClearanceTypeName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPENAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.SortNo)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ClearanceZone>(entity =>
        {
            entity.HasKey(e => new { e.FacilType, e.ZoneNo }).HasName("ESL_CLEARANCEZONES_PK");

            entity.ToTable("ESL_CLEARANCEZONES");

            entity.Property(e => e.FacilType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.ZoneNo)
                .HasPrecision(3)
                .HasColumnName("ZONENO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.FacilNo)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.SortNo)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.ZoneDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ZONEDESCRIPTION");
        });

        modelBuilder.Entity<EslConstant>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_CONSTANTS");

            entity.HasIndex(e => new { e.Facilno, e.Constantname, e.Startdate }, "ESL_CONSTANTS_PK").IsUnique();

            entity.Property(e => e.Constantname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CONSTANTNAME");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Startdate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Value)
                .HasColumnType("NUMBER")
                .HasColumnName("VALUE");
        });

        modelBuilder.Entity<EslDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_DETAILS");

            entity.HasIndex(e => new { e.FacilNo, e.DetailsNo }, "ESL_DETAILS_PK").IsUnique();

            entity.Property(e => e.DetailsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DETAILSNAME");
            entity.Property(e => e.DetailsNo)
                .HasPrecision(3)
                .HasColumnName("DETAILSNO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.FacilNo)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.FacilType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.SortNo)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.SubjNo)
                .HasPrecision(2)
                .HasColumnName("SUBJNO");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeNo).HasName("EMPLOYEES_PK");

            entity.ToTable("ESL_EMPLOYEES");

            entity.Property(e => e.EmployeeNo)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("EMPLOYEENO");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COMPANY");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.FacilNo)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GROUPNAME");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JOBTITLE");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        //#region ViewBuilders
        //modelBuilder.Entity<EslEOS>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_EOS_PK");

        //    entity.ToTable("ESL_EOS");

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EquipmentInvolved)
        //        .HasMaxLength(120)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPMENTINVOLVED");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReleasedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDBY");
        //    entity.Property(e => e.ReleasedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("RELEASEDDATE");
        //    entity.Property(e => e.ReleasedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASEDTIME");
        //    entity.Property(e => e.ReleaseType)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASETYPE");
        //    entity.Property(e => e.ReportedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDBY");
        //    entity.Property(e => e.ReportedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("REPORTEDDATE");
        //    entity.Property(e => e.ReportedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("REPORTEDTIME");
        //    entity.Property(e => e.ReportedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDTO");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(4)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.TagsInstalled)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSINSTALLED");
        //    entity.Property(e => e.TagsRemoved)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSREMOVED");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<EquipmentInvolved>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.EquipNo }).HasName("ESL_EQUIPMENTINVOLVED_PK");

        //    entity.ToTable("ESL_EQUIPMENTINVOLVED");

        //    entity.HasIndex(e => new { e.FacilNo, e.FacilType, e.EquipName }, "ESL_EQUIPMENTINVOLVED_UNQ").IsUnique();

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(3)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.EquipNo)
        //        .HasPrecision(3)
        //        .HasColumnName("EQUIPNO");
        //    entity.Property(e => e.Disable)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("DISABLE");
        //    entity.Property(e => e.EquipName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPNAME");
        //    entity.Property(e => e.FacilType)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILTYPE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<Facility>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_FACILITIES");

        //    entity.HasIndex(e => e.FacilNo, "ESL_FACILITIES_PK").IsUnique();

        //    entity.Property(e => e.Disable)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("DISABLE");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilFullName)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILFULLNAME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(3)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.FacilType)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILTYPE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.SortNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SORTNO");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.VisibleTo)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("VISIBLETO");
        //});

        //modelBuilder.Entity<EslFlowchange>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_FLOWCHANGES_PK");

        //    entity.ToTable("ESL_FLOWCHANGES");

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.Accepted)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("ACCEPTED");
        //    entity.Property(e => e.ChangeBy)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("CHANGEBY");
        //    entity.Property(e => e.ChangeByUnit)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("CHANGEBYUNIT");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.MeterID)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("METERID");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.NewValue)
        //        .HasColumnType("NUMBER(10,2)")
        //        .HasColumnName("NEWVALUE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OffTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("OFFTIME");
        //    entity.Property(e => e.OldUnit)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("OLDUNIT");
        //    entity.Property(e => e.OldValue)
        //        .HasColumnType("NUMBER(10,2)")
        //        .HasColumnName("OLDVALUE");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.RequestedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REQUESTEDBY");
        //    entity.Property(e => e.RequestedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("REQUESTEDDATE");
        //    entity.Property(e => e.RequestedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("REQUESTEDTIME");
        //    entity.Property(e => e.RequestedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("REQUESTEDTO");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(6)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.Unit)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("UNIT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<EslGeneral>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_GENERAL_PK");

        //    entity.ToTable("ESL_GENERAL");

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(600)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReportedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDBY");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(6)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<EslLogStatus>(entity =>
        //{
        //    entity.HasKey(e => e.LogStatusNo).HasName("ESL_LOGSTATUS_PK");

        //    entity.ToTable("ESL_LOGSTATUS");

        //    entity.Property(e => e.LogStatusNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("LOGSTATUSNO");
        //    entity.Property(e => e.LogStatusDescription)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGSTATUS");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //});

        //modelBuilder.Entity<LogType>(entity =>
        //{
        //    entity.HasKey(e => e.LogTypeNo).HasName("ESL_LOGTYPES_PK");

        //    entity.ToTable("ESL_LOGTYPES");

        //    entity.HasIndex(e => new { e.LogTypeNo, e.LogTypeName }, "ESL_LOGTYPES_UNQ").IsUnique();

        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<EslMeter>(entity =>
        //{
        //    entity.HasKey(e => new { e.Facilno, e.Meterid }).HasName("ESL_METERS_PK");

        //    entity.ToTable("ESL_METERS");

        //    entity.Property(e => e.Facilno)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.Meterid)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("METERID");
        //    entity.Property(e => e.Disable)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("DISABLE");
        //    entity.Property(e => e.Metertype)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("METERTYPE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.Sortno)
        //        .HasPrecision(2)
        //        .HasColumnName("SORTNO");
        //    entity.Property(e => e.Updatedate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.Updatedby)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<PlantShift>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.ShiftNo }).HasName("PLANTSHIFT_PK");

        //    entity.ToTable("ESL_PLANTSHIFTS");

        //    entity.HasIndex(e => new { e.FacilNo, e.ShiftNo, e.ShiftStart, e.ShiftEnd }, "ESL_PLANTSHIFTS_UNQ").IsUnique();

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.ShiftEnd)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("SHIFTEND");
        //    entity.Property(e => e.ShiftName)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("SHIFTNAME");
        //    entity.Property(e => e.ShiftStart)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("SHIFTSTART");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<RelatedTo>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_RELATEDTO");

        //    entity.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.RelatedToSubject }, "ESL_RELATEDTO_PK").IsUnique();

        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.RelatedToSubject)
        //        .HasMaxLength(120)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO_SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<RptAllEvent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_RPT_ALLEVENTS");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(120)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedByName)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBYNAME");
        //});

        //modelBuilder.Entity<RptMisc>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_RPT_MISC");

        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeSpecific)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPE_SPECIFIC");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ServerFacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SERVERFACILNO");
        //});

        //modelBuilder.Entity<ScanDoc>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_SCANDOCS");

        //    entity.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.ScanNo }, "ESL_SCANDOCS_PK").IsUnique();

        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.ScanFileName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("SCANFILENAME");
        //    entity.Property(e => e.ScanNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SCANNO");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ScanLob>(entity =>
        //{
        //    entity.HasKey(e => e.ScanSeqNo).HasName("ESL_SCANLOBS_PK");

        //    entity.ToTable("ESL_SCANLOBS");

        //    entity.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.ScanNo }, "SCANLOB_DOC_IDX");

        //    entity.Property(e => e.ScanSeqNo)
        //        .HasColumnType("NUMBER(38)")
        //        .HasColumnName("SCANSEQNO");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.ScanBlob)
        //        .HasDefaultValueSql("EMPTY_BLOB()")
        //        .HasColumnType("BLOB")
        //        .HasColumnName("SCANBLOB");
        //    entity.Property(e => e.ScanFileName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("SCANFILENAME");
        //    entity.Property(e => e.ScanLobType)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("SCANLOBTYPE");
        //    entity.Property(e => e.ScanNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SCANNO");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<EslSOC>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_SOC_PK");

        //    entity.ToTable("ESL_SOC");

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EquipmentInvolved)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPMENTINVOLVED");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.Limitations)
        //        .HasMaxLength(600)
        //        .IsUnicode(false)
        //        .HasColumnName("LIMITATIONS");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReleasedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDBY");
        //    entity.Property(e => e.ReleasedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("RELEASEDDATE");
        //    entity.Property(e => e.ReleasedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASEDTIME");
        //    entity.Property(e => e.ReleasedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDTO");
        //    entity.Property(e => e.ReleaseType)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASETYPE");
        //    entity.Property(e => e.ReportedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDBY");
        //    entity.Property(e => e.ReportedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("REPORTEDDATE");
        //    entity.Property(e => e.ReportedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("REPORTEDTIME");
        //    entity.Property(e => e.ReportedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDTO");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(4)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.TagsRemoved)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSREMOVED");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<EslSubject>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.SubjNo }).HasName("ESL_SUBJECTS_PK");

        //    entity.ToTable("ESL_SUBJECTS");

        //    entity.HasIndex(e => new { e.FacilNo, e.FacilType, e.SubjName }, "ESL_SUBJECTS_UNQ").IsUnique();

        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.SubjNo)
        //        .HasPrecision(3)
        //        .HasColumnName("SUBJNO");
        //    entity.Property(e => e.Disable)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("DISABLE");
        //    entity.Property(e => e.FacilType)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILTYPE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.SortNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SORTNO");
        //    entity.Property(e => e.SubjName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJNAME");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<EslUnit>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_UNITS");

        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.UnitDesc)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("UNITDESC");
        //    entity.Property(e => e.UnitName)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("UNITNAME");
        //    entity.Property(e => e.UnitNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("UNITNO");
        //    entity.Property(e => e.UpdateBy)
        //        .HasMaxLength(80)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEBY");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //});

        //modelBuilder.Entity<WorkOrder>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ESL_WORKORDERS");

        //    entity.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.WoNo }, "ESL_WORKORDERS_PK").IsUnique();

        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WoNo)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("WO_NO");
        //});

        //modelBuilder.Entity<WorkToBePerformed>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilType, e.WorkNo }).HasName("WORKTOBEPERFORMED_PK");

        //    entity.ToTable("ESL_WORKTOBEPERFORMED");

        //    entity.Property(e => e.FacilType)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILTYPE");
        //    entity.Property(e => e.WorkNo)
        //        .HasPrecision(3)
        //        .HasColumnName("WORKNO");
        //    entity.Property(e => e.Disable)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("DISABLE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.SortNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SORTNO");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkDescription)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKDESCRIPTION");
        //});

        //modelBuilder.Entity<ViewAllEventsCurrent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_ALLEVENTS_CURRENT");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewAllEventsFacilNo>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_ALLEVENTS_FACILNOS");

        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //});

        //modelBuilder.Entity<ViewAllEventsLogType>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_ALLEVENTS_LOGTYPES");

        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //});

        //modelBuilder.Entity<ViewAllEventsRelatedTo>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_ALLEVENTS_RELATEDTO");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewAllEventsSearch>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_ALLEVENTS_SEARCH");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewClearanceAll>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_CLEARANCE_ALL");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewClearanceOutstanding>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_CLEARANCE_OUTSTANDING");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewClearanceIssue>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_CLEARANCEISSUES");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.ClearanceType)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCETYPE");
        //    entity.Property(e => e.ClearanceZone)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEZONE");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.Creator)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("CREATOR");
        //    entity.Property(e => e.EquipmentInvolved)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPMENTINVOLVED");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.IssuedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("ISSUEDBY");
        //    entity.Property(e => e.IssuedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("ISSUEDDATE");
        //    entity.Property(e => e.IssuedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("ISSUEDTIME");
        //    entity.Property(e => e.IssuedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("ISSUEDTO");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.Operator)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATOR");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReleasedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDBY");
        //    entity.Property(e => e.ReleasedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("RELEASEDDATE");
        //    entity.Property(e => e.ReleasedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASEDTIME");
        //    entity.Property(e => e.ReleasedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDTO");
        //    entity.Property(e => e.ReleaseType)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASETYPE");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(4)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.TagsRemoved)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSREMOVED");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.WorkToBePerformed)
        //        .HasMaxLength(600)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKTOBEPERFORMED");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<ViewClearanceIssuesCurrent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_CLEARANCEISSUES_CURRENT");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.ClearanceType)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCETYPE");
        //    entity.Property(e => e.ClearanceZone)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEZONE");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EquipmentInvolved)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPMENTINVOLVED");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.IssuedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("ISSUEDBY");
        //    entity.Property(e => e.IssuedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("ISSUEDDATE");
        //    entity.Property(e => e.IssuedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("ISSUEDTIME");
        //    entity.Property(e => e.IssuedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("ISSUEDTO");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReleasedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDBY");
        //    entity.Property(e => e.ReleasedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("RELEASEDDATE");
        //    entity.Property(e => e.ReleasedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASEDTIME");
        //    entity.Property(e => e.ReleasedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDTO");
        //    entity.Property(e => e.ReleaseType)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASETYPE");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(4)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.TagsRemoved)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSREMOVED");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.WorkToBePerformed)
        //        .HasMaxLength(600)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKTOBEPERFORMED");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<ViewClearanceType>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_CLEARANCETYPES");

        //    entity.Property(e => e.ClearanceType)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCETYPE");
        //    entity.Property(e => e.ClearanceTypeName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCETYPENAME");
        //    entity.Property(e => e.ClearanceTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("CLEARANCETYPENO");
        //});

        //modelBuilder.Entity<ViewEOSAll>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_EOS_ALL");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewEOSCurrent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_EOS_CURRENT");

        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EquipmentInvolved)
        //        .HasMaxLength(120)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPMENTINVOLVED");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReleasedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDBY");
        //    entity.Property(e => e.ReleasedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("RELEASEDDATE");
        //    entity.Property(e => e.ReleasedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASEDTIME");
        //    entity.Property(e => e.ReleaseType)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASETYPE");
        //    entity.Property(e => e.ReportedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDBY");
        //    entity.Property(e => e.ReportedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("REPORTEDDATE");
        //    entity.Property(e => e.ReportedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("REPORTEDTIME");
        //    entity.Property(e => e.ReportedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDTO");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(4)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.TagsInstalled)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSINSTALLED");
        //    entity.Property(e => e.TagsRemoved)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSREMOVED");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<ViewEOSOutstanding>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_EOS_OUTSTANDING");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewFlowChangeAll>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_FLOWCHANGE_ALL");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewFlowChangePresched>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_FLOWCHANGE_PRESCHED");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewFlowChangesCurrent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_FLOWCHANGES_CURRENT");

        //    entity.Property(e => e.Accepted)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("ACCEPTED");
        //    entity.Property(e => e.ChangeBy)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("CHANGEBY");
        //    entity.Property(e => e.ChangeByUnit)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("CHANGEBYUNIT");
        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.MeterID)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("METERID");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.NewValue)
        //        .HasColumnType("NUMBER(10,2)")
        //        .HasColumnName("NEWVALUE");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OffTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("OFFTIME");
        //    entity.Property(e => e.OldUnit)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("OLDUNIT");
        //    entity.Property(e => e.OldValue)
        //        .HasColumnType("NUMBER(10,2)")
        //        .HasColumnName("OLDVALUE");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.RequestedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REQUESTEDBY");
        //    entity.Property(e => e.RequestedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("REQUESTEDDATE");
        //    entity.Property(e => e.RequestedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("REQUESTEDTIME");
        //    entity.Property(e => e.RequestedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("REQUESTEDTO");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(6)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.Unit)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("UNIT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<ViewGeneralAll>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_GENERAL_ALL");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewGeneralCurrent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_GENERAL_CURRENT");

        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(600)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReportedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDBY");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(6)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<ViewGeneralOutstanding>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_GENERAL_OUTSTANDING");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewRealTime>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_REALTIME");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewSearchAllEvent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_SEARCH_ALLEVENTS");

        //    entity.Property(e => e.ClearanceID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("CLEARANCEID");
        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewSOCAll>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_SOC_ALL");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewSOCCurrent>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_SOC_CURRENT");

        //    entity.Property(e => e.CreatedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("CREATEDBY");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("CREATEDDATE");
        //    entity.Property(e => e.EquipmentInvolved)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("EQUIPMENTINVOLVED");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.FacilAbbr)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILABBR");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.Limitations)
        //        .HasMaxLength(600)
        //        .IsUnicode(false)
        //        .HasColumnName("LIMITATIONS");
        //    entity.Property(e => e.Location)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("LOCATION");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("MODIFIEDBY");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("MODIFIEDDATE");
        //    entity.Property(e => e.ModifyFlag)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("MODIFYFLAG");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.NotifiedFacil)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTIFIEDFACIL");
        //    entity.Property(e => e.NotifiedPerson)
        //        .HasPrecision(7)
        //        .HasColumnName("NOTIFIEDPERSON");
        //    entity.Property(e => e.OperatorID)
        //        .HasPrecision(7)
        //        .HasColumnName("OPERATORID");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.RelatedTo)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("RELATEDTO");
        //    entity.Property(e => e.ReleasedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDBY");
        //    entity.Property(e => e.ReleasedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("RELEASEDDATE");
        //    entity.Property(e => e.ReleasedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASEDTIME");
        //    entity.Property(e => e.ReleasedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("RELEASEDTO");
        //    entity.Property(e => e.ReleaseType)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("RELEASETYPE");
        //    entity.Property(e => e.ReportedBy)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDBY");
        //    entity.Property(e => e.ReportedDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("REPORTEDDATE");
        //    entity.Property(e => e.ReportedTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("REPORTEDTIME");
        //    entity.Property(e => e.ReportedTo)
        //        .HasPrecision(7)
        //        .HasColumnName("REPORTEDTO");
        //    entity.Property(e => e.SeqNo)
        //        .HasPrecision(4)
        //        .HasColumnName("SEQNO");
        //    entity.Property(e => e.ShiftNo)
        //        .HasPrecision(2)
        //        .HasColumnName("SHIFTNO");
        //    entity.Property(e => e.TagsRemoved)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("TAGSREMOVED");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WorkOrders)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("WORKORDERS");
        //    entity.Property(e => e.Yr)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .HasColumnName("YR");
        //});

        //modelBuilder.Entity<ViewSOCOutstanding>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_SOC_OUTSTANDING");

        //    entity.Property(e => e.Details)
        //        .HasMaxLength(2000)
        //        .IsUnicode(false)
        //        .HasColumnName("DETAILS");
        //    entity.Property(e => e.EventDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("EVENTDATE");
        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.EventID_RevNo)
        //        .HasPrecision(2)
        //        .HasColumnName("EVENTID_REVNO");
        //    entity.Property(e => e.EventTime)
        //        .HasMaxLength(5)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTTIME");
        //    entity.Property(e => e.FacilName)
        //        .HasMaxLength(40)
        //        .IsUnicode(false)
        //        .HasColumnName("FACILNAME");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("LOGTYPENAME");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.OperatorType)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("OPERATORTYPE");
        //    entity.Property(e => e.ScanDocsNo)
        //        .HasColumnType("NUMBER")
        //        .HasColumnName("SCANDOCSNO");
        //    entity.Property(e => e.Subject)
        //        .HasMaxLength(300)
        //        .IsUnicode(false)
        //        .HasColumnName("SUBJECT");
        //    entity.Property(e => e.UpdateDate)
        //        .HasMaxLength(19)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(101)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //});

        //modelBuilder.Entity<ViewWorkOrder>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VIEW_WORKORDERS");

        //    entity.Property(e => e.EventID)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("EVENTID");
        //    entity.Property(e => e.FacilNo)
        //        .HasPrecision(2)
        //        .HasColumnName("FACILNO");
        //    entity.Property(e => e.LogTypeNo)
        //        .HasPrecision(2)
        //        .HasColumnName("LOGTYPENO");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(400)
        //        .IsUnicode(false)
        //        .HasColumnName("NOTES");
        //    entity.Property(e => e.UpdateDate)
        //        .HasColumnType("DATE")
        //        .HasColumnName("UPDATEDATE");
        //    entity.Property(e => e.UpdatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("UPDATEDBY");
        //    entity.Property(e => e.WoNo)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("WO_NO");
        //});

        //#endregion ViewBuilders

        modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
