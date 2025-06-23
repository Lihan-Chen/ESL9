using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc.DataAccess;

public partial class EslViewContext : DbContext //, IEslViewContext
{
    public EslViewContext()
    {
    }

    public EslViewContext(DbContextOptions<EslViewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllEvent> AllEvents { get; set; }

    public virtual DbSet<EslAllscadausersRole> EslAllscadausersRoles { get; set; }

    public virtual DbSet<EslCallouttype> EslCallouttypes { get; set; }

    public virtual DbSet<EslClearanceissue> EslClearanceissues { get; set; }

    public virtual DbSet<EslClearancetype> EslClearancetypes { get; set; }

    public virtual DbSet<EslClearancezone> EslClearancezones { get; set; }

    public virtual DbSet<EslConstant> EslConstants { get; set; }

    public virtual DbSet<EslDetail> EslDetails { get; set; }

    public virtual DbSet<EslEmployee> EslEmployees { get; set; }

    public virtual DbSet<EslEmployeesWsoP> EslEmployeesWsoPs { get; set; }

    public virtual DbSet<EslEo> EslEos { get; set; }

    public virtual DbSet<EslEquipmentinvolved> EslEquipmentinvolveds { get; set; }

    public virtual DbSet<EslFacil> EslFacils { get; set; }

    public virtual DbSet<EslFacility> EslFacilities { get; set; }

    public virtual DbSet<EslFlowchange> EslFlowchanges { get; set; }

    public virtual DbSet<EslGeneral> EslGenerals { get; set; }

    public virtual DbSet<EslLogstatus> EslLogstatuses { get; set; }

    public virtual DbSet<EslLogtablename> EslLogtablenames { get; set; }

    public virtual DbSet<EslLogtype> EslLogtypes { get; set; }

    public virtual DbSet<EslMeter> EslMeters { get; set; }

    public virtual DbSet<EslPlantshift> EslPlantshifts { get; set; }

    public virtual DbSet<EslRelatedto> EslRelatedtos { get; set; }

    public virtual DbSet<EslRptAllevent> EslRptAllevents { get; set; }

    public virtual DbSet<EslRptMisc> EslRptMiscs { get; set; }

    public virtual DbSet<EslScadarole> EslScadaroles { get; set; }

    public virtual DbSet<EslScandoc> EslScandocs { get; set; }

    public virtual DbSet<EslScanlob> EslScanlobs { get; set; }

    public virtual DbSet<EslSoc> EslSocs { get; set; }

    public virtual DbSet<EslSubject> EslSubjects { get; set; }

    public virtual DbSet<EslUnit> EslUnits { get; set; }

    public virtual DbSet<EslUserInfoVw> EslUserInfoVws { get; set; }

    public virtual DbSet<EslWebtransaction> EslWebtransactions { get; set; }

    public virtual DbSet<EslWorkorder> EslWorkorders { get; set; }

    public virtual DbSet<EslWorktobeperformed> EslWorktobeperformeds { get; set; }

    public virtual DbSet<PlsqlProfilerDatum> PlsqlProfilerData { get; set; }

    public virtual DbSet<PlsqlProfilerRun> PlsqlProfilerRuns { get; set; }

    public virtual DbSet<PlsqlProfilerUnit> PlsqlProfilerUnits { get; set; }

    public virtual DbSet<QuestSlTempExplain1> QuestSlTempExplain1s { get; set; }

    public virtual DbSet<TempEslEmployeesP> TempEslEmployeesPs { get; set; }

    public virtual DbSet<ToadPlanSql> ToadPlanSqls { get; set; }

    public virtual DbSet<ToadPlanTable> ToadPlanTables { get; set; }

    public virtual DbSet<ViewAlleventsCurrent> ViewAlleventsCurrents { get; set; }

    public virtual DbSet<ViewAlleventsFacilno> ViewAlleventsFacilnos { get; set; }

    public virtual DbSet<ViewAlleventsLogtype> ViewAlleventsLogtypes { get; set; }

    public virtual DbSet<ViewAlleventsRelatedto> ViewAlleventsRelatedtos { get; set; }

    public virtual DbSet<ViewAlleventsSearch> ViewAlleventsSearches { get; set; }

    public virtual DbSet<ViewClearanceAll> ViewClearanceAlls { get; set; }

    public virtual DbSet<ViewClearanceOutstanding> ViewClearanceOutstandings { get; set; }

    public virtual DbSet<ViewClearanceissue> ViewClearanceissues { get; set; }

    public virtual DbSet<ViewClearanceissuesCurrent> ViewClearanceissuesCurrents { get; set; }

    public virtual DbSet<ViewClearancetype> ViewClearancetypes { get; set; }

    public virtual DbSet<ViewEosAll> ViewEosAlls { get; set; }

    public virtual DbSet<ViewEosCurrent> ViewEosCurrents { get; set; }

    public virtual DbSet<ViewEosOutstanding> ViewEosOutstandings { get; set; }

    public virtual DbSet<ViewFlowchangeAll> ViewFlowchangeAlls { get; set; }

    public virtual DbSet<ViewFlowchangePresched> ViewFlowchangePrescheds { get; set; }

    public virtual DbSet<ViewFlowchangesCurrent> ViewFlowchangesCurrents { get; set; }

    public virtual DbSet<ViewGeneralAll> ViewGeneralAlls { get; set; }

    public virtual DbSet<ViewGeneralCurrent> ViewGeneralCurrents { get; set; }

    public virtual DbSet<ViewGeneralOutstanding> ViewGeneralOutstandings { get; set; }

    public virtual DbSet<ViewRealtime> ViewRealtimes { get; set; }

    public virtual DbSet<ViewSearchAllevent> ViewSearchAllevents { get; set; }

    public virtual DbSet<ViewSocAll> ViewSocAlls { get; set; }

    public virtual DbSet<ViewSocCurrent> ViewSocCurrents { get; set; }

    public virtual DbSet<ViewSocOutstanding> ViewSocOutstandings { get; set; }

    public virtual DbSet<ViewWorkorder> ViewWorkorders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=odev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ESL")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<EslAllevent>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.EventidRevno }).HasName("ESL_ALLEVENTS_PK");

            entity.ToTable("ESL_ALLEVENTS");

            entity.HasIndex(e => e.Updatedate, "UPDATEDATE");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslAllscadausersRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_ALLSCADAUSERS_ROLE");

            entity.HasIndex(e => new { e.Facilno, e.Userid }, "ESL_ALLSCADAUSERS_USERID_IDX");

            entity.Property(e => e.AdminOption)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ADMIN_OPTION");
            entity.Property(e => e.DefaultRole)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DEFAULT_ROLE");
            entity.Property(e => e.Facilno)
                .HasColumnType("NUMBER")
                .HasColumnName("FACILNO");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ROLE");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Userid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USERID");
        });

        modelBuilder.Entity<EslCallouttype>(entity =>
        {
            entity.HasKey(e => e.Callouttypeno).HasName("ESL_CALLOUTTYPES_PK");

            entity.ToTable("ESL_CALLOUTTYPES");

            entity.Property(e => e.Callouttypeno)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CALLOUTTYPENO");
            entity.Property(e => e.Callouttypename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CALLOUTTYPENAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslClearanceissue>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.EventidRevno }).HasName("ESL_CLEARANCEISSUES_PK");

            entity.ToTable("ESL_CLEARANCEISSUES");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Clearancetype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPE");
            entity.Property(e => e.Clearancezone)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEZONE");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Issuedby)
                .HasPrecision(7)
                .HasColumnName("ISSUEDBY");
            entity.Property(e => e.Issueddate)
                .HasColumnType("DATE")
                .HasColumnName("ISSUEDDATE");
            entity.Property(e => e.Issuedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ISSUEDTIME");
            entity.Property(e => e.Issuedto)
                .HasPrecision(7)
                .HasColumnName("ISSUEDTO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasedto)
                .HasPrecision(7)
                .HasColumnName("RELEASEDTO");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Worktobeperformed)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("WORKTOBEPERFORMED");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<EslClearancetype>(entity =>
        {
            entity.HasKey(e => e.Clearancetypeno).HasName("ESL_CLEARANCETYPES_PK");

            entity.ToTable("ESL_CLEARANCETYPES");

            entity.Property(e => e.Clearancetypeno)
                .HasPrecision(2)
                .HasColumnName("CLEARANCETYPENO");
            entity.Property(e => e.Clearancetypeabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPEABBR");
            entity.Property(e => e.Clearancetypename)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPENAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslClearancezone>(entity =>
        {
            entity.HasKey(e => new { e.Faciltype, e.Zoneno }).HasName("ESL_CLEARANCEZONES_PK");

            entity.ToTable("ESL_CLEARANCEZONES");

            entity.Property(e => e.Faciltype)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Zoneno)
                .HasPrecision(3)
                .HasColumnName("ZONENO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Facilno)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Zonedescription)
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

            entity.HasIndex(e => new { e.Facilno, e.Detailsno }, "ESL_DETAILS_PK").IsUnique();

            entity.Property(e => e.Detailsname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DETAILSNAME");
            entity.Property(e => e.Detailsno)
                .HasPrecision(3)
                .HasColumnName("DETAILSNO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Facilno)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Faciltype)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Subjno)
                .HasPrecision(2)
                .HasColumnName("SUBJNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslEmployee>(entity =>
        {
            entity.HasKey(e => e.Employeeno).HasName("EMPLOYEES_PK");

            entity.ToTable("ESL_EMPLOYEES");

            entity.Property(e => e.Employeeno)
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
            entity.Property(e => e.Facilno)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Groupname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GROUPNAME");
            entity.Property(e => e.Jobtitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JOBTITLE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslEmployeesWsoP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ESL_EMPLOYEES_WSO_PS");
        });

        modelBuilder.Entity<EslEo>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.EventidRevno }).HasName("ESL_EOS_PK");

            entity.ToTable("ESL_EOS");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Reportedby)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.Reporteddate)
                .HasColumnType("DATE")
                .HasColumnName("REPORTEDDATE");
            entity.Property(e => e.Reportedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REPORTEDTIME");
            entity.Property(e => e.Reportedto)
                .HasPrecision(7)
                .HasColumnName("REPORTEDTO");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsinstalled)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSINSTALLED");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<EslEquipmentinvolved>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Equipno }).HasName("ESL_EQUIPMENTINVOLVED_PK");

            entity.ToTable("ESL_EQUIPMENTINVOLVED");

            entity.HasIndex(e => new { e.Facilno, e.Faciltype, e.Equipname }, "ESL_EQUIPMENTINVOLVED_UNQ").IsUnique();

            entity.Property(e => e.Facilno)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Equipno)
                .HasPrecision(3)
                .HasColumnName("EQUIPNO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Equipname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EQUIPNAME");
            entity.Property(e => e.Faciltype)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslFacil>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_FACIL");

            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(5)
                .HasColumnName("FACILNO");
        });

        modelBuilder.Entity<EslFacility>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_FACILITIES");

            entity.HasIndex(e => e.Facilno, "ESL_FACILITIES_PK").IsUnique();

            entity.Property(e => e.Disable)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilfullname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FACILFULLNAME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(3)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Faciltype)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Visibleto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("VISIBLETO");
        });

        modelBuilder.Entity<EslFlowchange>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.EventidRevno }).HasName("ESL_FLOWCHANGES_PK");

            entity.ToTable("ESL_FLOWCHANGES");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Accepted)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ACCEPTED");
            entity.Property(e => e.Changeby)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHANGEBY");
            entity.Property(e => e.Changebyunit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHANGEBYUNIT");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Meterid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("METERID");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Newvalue)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("NEWVALUE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Offtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("OFFTIME");
            entity.Property(e => e.Oldunit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OLDUNIT");
            entity.Property(e => e.Oldvalue)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("OLDVALUE");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Requestedby)
                .HasPrecision(7)
                .HasColumnName("REQUESTEDBY");
            entity.Property(e => e.Requesteddate)
                .HasColumnType("DATE")
                .HasColumnName("REQUESTEDDATE");
            entity.Property(e => e.Requestedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REQUESTEDTIME");
            entity.Property(e => e.Requestedto)
                .HasPrecision(7)
                .HasColumnName("REQUESTEDTO");
            entity.Property(e => e.Seqno)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UNIT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<EslGeneral>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.EventidRevno }).HasName("ESL_GENERAL_PK");

            entity.ToTable("ESL_GENERAL");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Details)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Reportedby)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.Seqno)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<EslLogstatus>(entity =>
        {
            entity.HasKey(e => e.Logstatusno).HasName("ESL_LOGSTATUS_PK");

            entity.ToTable("ESL_LOGSTATUS");

            entity.Property(e => e.Logstatusno)
                .HasColumnType("NUMBER")
                .HasColumnName("LOGSTATUSNO");
            entity.Property(e => e.Logstatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LOGSTATUS");
            entity.Property(e => e.Notes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOTES");
        });

        modelBuilder.Entity<EslLogtablename>(entity =>
        {
            entity.HasKey(e => e.Logtypeno).HasName("ESL_LOGNAMES_PK");

            entity.ToTable("ESL_LOGTABLENAMES");

            entity.Property(e => e.Logtypeno)
                .HasColumnType("NUMBER")
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Logtablename)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LOGTABLENAME");
        });

        modelBuilder.Entity<EslLogtype>(entity =>
        {
            entity.HasKey(e => e.Logtypeno).HasName("ESL_LOGTYPES_PK");

            entity.ToTable("ESL_LOGTYPES");

            entity.HasIndex(e => new { e.Logtypeno, e.Logtypename }, "ESL_LOGTYPES_UNQ").IsUnique();

            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslMeter>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Meterid }).HasName("ESL_METERS_PK");

            entity.ToTable("ESL_METERS");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Meterid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("METERID");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Metertype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("METERTYPE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslPlantshift>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Shiftno }).HasName("PLANTSHIFT_PK");

            entity.ToTable("ESL_PLANTSHIFTS");

            entity.HasIndex(e => new { e.Facilno, e.Shiftno, e.Shiftstart, e.Shiftend }, "ESL_PLANTSHIFTS_UNQ").IsUnique();

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Shiftend)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SHIFTEND");
            entity.Property(e => e.Shiftname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SHIFTNAME");
            entity.Property(e => e.Shiftstart)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SHIFTSTART");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslRelatedto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_RELATEDTO");

            entity.HasIndex(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.RelatedtoSubject }, "ESL_RELATEDTO_PK").IsUnique();

            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.RelatedtoSubject)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO_SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslRptAllevent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_RPT_ALLEVENTS");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Subject)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedbyname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBYNAME");
        });

        modelBuilder.Entity<EslRptMisc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_RPT_MISC");

            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogtypeSpecific)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("LOGTYPE_SPECIFIC");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Serverfacilno)
                .HasPrecision(2)
                .HasColumnName("SERVERFACILNO");
        });

        modelBuilder.Entity<EslScadarole>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Grantee, e.Role }).HasName("ESL_SCADAROLES_TEST_PK");

            entity.ToTable("ESL_SCADAROLES");

            entity.HasIndex(e => new { e.Facilno, e.Grantee }, "ESL_SCADAROLE_USERID_IDX");

            entity.Property(e => e.Facilno)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FACILNO");
            entity.Property(e => e.Grantee)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GRANTEE");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ROLE");
            entity.Property(e => e.AdminOption)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ADMIN_OPTION");
            entity.Property(e => e.DefaultRole)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DEFAULT_ROLE");
        });

        modelBuilder.Entity<EslScandoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_SCANDOCS");

            entity.HasIndex(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.Scanno }, "ESL_SCANDOCS_PK").IsUnique();

            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Scanfilename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SCANFILENAME");
            entity.Property(e => e.Scanno)
                .HasPrecision(2)
                .HasColumnName("SCANNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslScanlob>(entity =>
        {
            entity.HasKey(e => e.Scanseqno).HasName("ESL_SCANLOBS_PK");

            entity.ToTable("ESL_SCANLOBS");

            entity.HasIndex(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.Scanno }, "SCANLOB_DOC_IDX");

            entity.Property(e => e.Scanseqno)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SCANSEQNO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Notes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Scanblob)
                .HasDefaultValueSql("EMPTY_BLOB()")
                .HasColumnType("BLOB")
                .HasColumnName("SCANBLOB");
            entity.Property(e => e.Scanfilename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SCANFILENAME");
            entity.Property(e => e.Scanlobtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SCANLOBTYPE");
            entity.Property(e => e.Scanno)
                .HasPrecision(2)
                .HasColumnName("SCANNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslSoc>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.EventidRevno }).HasName("ESL_SOC_PK");

            entity.ToTable("ESL_SOC");

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Limitations)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("LIMITATIONS");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasedto)
                .HasPrecision(7)
                .HasColumnName("RELEASEDTO");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Reportedby)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.Reporteddate)
                .HasColumnType("DATE")
                .HasColumnName("REPORTEDDATE");
            entity.Property(e => e.Reportedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REPORTEDTIME");
            entity.Property(e => e.Reportedto)
                .HasPrecision(7)
                .HasColumnName("REPORTEDTO");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<EslSubject>(entity =>
        {
            entity.HasKey(e => new { e.Facilno, e.Subjno }).HasName("ESL_SUBJECTS_PK");

            entity.ToTable("ESL_SUBJECTS");

            entity.HasIndex(e => new { e.Facilno, e.Faciltype, e.Subjname }, "ESL_SUBJECTS_UNQ").IsUnique();

            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Subjno)
                .HasPrecision(3)
                .HasColumnName("SUBJNO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Faciltype)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Subjname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUBJNAME");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<EslUnit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_UNITS");

            entity.Property(e => e.Notes)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Unitdesc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("UNITDESC");
            entity.Property(e => e.Unitname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UNITNAME");
            entity.Property(e => e.Unitno)
                .HasColumnType("NUMBER")
                .HasColumnName("UNITNO");
            entity.Property(e => e.Updateby)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("UPDATEBY");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
        });

        modelBuilder.Entity<EslUserInfoVw>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ESL_USER_INFO_VW");

            entity.Property(e => e.Deptname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DEPTNAME");
            entity.Property(e => e.Emplid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("EMPLID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.InternetId)
                .HasMaxLength(41)
                .IsUnicode(false)
                .HasColumnName("INTERNET_ID");
            entity.Property(e => e.Jobtitle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("JOBTITLE");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.MBranchDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_BRANCH_DESC");
            entity.Property(e => e.MDivisionDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_DIVISION_DESC");
            entity.Property(e => e.MSectionDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_SECTION_DESC");
            entity.Property(e => e.MUnitDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_UNIT_DESC");
            entity.Property(e => e.MailDrop)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAIL_DROP");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("WORK_PHONE");
        });

        modelBuilder.Entity<EslWebtransaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("ESL_WEBTRANSACTIONS_PK");

            entity.ToTable("ESL_WEBTRANSACTIONS");

            entity.Property(e => e.Transactionid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRANSACTIONID");
            entity.Property(e => e.Errormessage)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ERRORMESSAGE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasColumnType("NUMBER")
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Facilno)
                .HasColumnType("NUMBER")
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasColumnType("NUMBER")
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Transactiontimestamp)
                .HasPrecision(6)
                .HasColumnName("TRANSACTIONTIMESTAMP");
            entity.Property(e => e.Updatedate)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
        });

        modelBuilder.Entity<EslWorkorder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESL_WORKORDERS");

            entity.HasIndex(e => new { e.Facilno, e.Logtypeno, e.Eventid, e.WoNo }, "ESL_WORKORDERS_PK").IsUnique();

            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.WoNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WO_NO");
        });

        modelBuilder.Entity<EslWorktobeperformed>(entity =>
        {
            entity.HasKey(e => new { e.Faciltype, e.Workno }).HasName("WORKTOBEPERFORMED_PK");

            entity.ToTable("ESL_WORKTOBEPERFORMED");

            entity.Property(e => e.Faciltype)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILTYPE");
            entity.Property(e => e.Workno)
                .HasPrecision(3)
                .HasColumnName("WORKNO");
            entity.Property(e => e.Disable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISABLE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Sortno)
                .HasPrecision(2)
                .HasColumnName("SORTNO");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workdescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("WORKDESCRIPTION");
        });

        modelBuilder.Entity<PlsqlProfilerDatum>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.UnitNumber, e.Line }).HasName("SYS_C008041");

            entity.ToTable("PLSQL_PROFILER_DATA", tb => tb.HasComment("Accumulated data from all profiler runs"));

            entity.Property(e => e.Runid)
                .HasColumnType("NUMBER")
                .HasColumnName("RUNID");
            entity.Property(e => e.UnitNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("UNIT_NUMBER");
            entity.Property(e => e.Line)
                .HasColumnType("NUMBER")
                .HasColumnName("LINE#");
            entity.Property(e => e.MaxTime)
                .HasColumnType("NUMBER")
                .HasColumnName("MAX_TIME");
            entity.Property(e => e.MinTime)
                .HasColumnType("NUMBER")
                .HasColumnName("MIN_TIME");
            entity.Property(e => e.Spare1)
                .HasColumnType("NUMBER")
                .HasColumnName("SPARE1");
            entity.Property(e => e.Spare2)
                .HasColumnType("NUMBER")
                .HasColumnName("SPARE2");
            entity.Property(e => e.Spare3)
                .HasColumnType("NUMBER")
                .HasColumnName("SPARE3");
            entity.Property(e => e.Spare4)
                .HasColumnType("NUMBER")
                .HasColumnName("SPARE4");
            entity.Property(e => e.Text)
                .IsUnicode(false)
                .HasColumnName("TEXT");
            entity.Property(e => e.TotalOccur)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_OCCUR");
            entity.Property(e => e.TotalTime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_TIME");

            entity.HasOne(d => d.PlsqlProfilerUnit).WithMany(p => p.PlsqlProfilerData)
                .HasForeignKey(d => new { d.Runid, d.UnitNumber })
                .HasConstraintName("SYS_C008061");
        });

        modelBuilder.Entity<PlsqlProfilerRun>(entity =>
        {
            entity.HasKey(e => e.Runid).HasName("SYS_C008042");

            entity.ToTable("PLSQL_PROFILER_RUNS", tb => tb.HasComment("Run-specific information for the PL/SQL profiler"));

            entity.Property(e => e.Runid)
                .HasColumnType("NUMBER")
                .HasColumnName("RUNID");
            entity.Property(e => e.RelatedRun)
                .HasColumnType("NUMBER")
                .HasColumnName("RELATED_RUN");
            entity.Property(e => e.RunComment)
                .HasMaxLength(2047)
                .IsUnicode(false)
                .HasColumnName("RUN_COMMENT");
            entity.Property(e => e.RunComment1)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("RUN_COMMENT1");
            entity.Property(e => e.RunDate)
                .HasColumnType("DATE")
                .HasColumnName("RUN_DATE");
            entity.Property(e => e.RunOwner)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("RUN_OWNER");
            entity.Property(e => e.RunProc)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("RUN_PROC");
            entity.Property(e => e.RunSystemInfo)
                .HasMaxLength(2047)
                .IsUnicode(false)
                .HasColumnName("RUN_SYSTEM_INFO");
            entity.Property(e => e.RunTotalTime)
                .HasColumnType("NUMBER")
                .HasColumnName("RUN_TOTAL_TIME");
            entity.Property(e => e.Spare1)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("SPARE1");
        });

        modelBuilder.Entity<PlsqlProfilerUnit>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.UnitNumber }).HasName("SYS_C008043");

            entity.ToTable("PLSQL_PROFILER_UNITS", tb => tb.HasComment("Information about each library unit in a run"));

            entity.Property(e => e.Runid)
                .HasColumnType("NUMBER")
                .HasColumnName("RUNID");
            entity.Property(e => e.UnitNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("UNIT_NUMBER");
            entity.Property(e => e.Spare1)
                .HasColumnType("NUMBER")
                .HasColumnName("SPARE1");
            entity.Property(e => e.Spare2)
                .HasColumnType("NUMBER")
                .HasColumnName("SPARE2");
            entity.Property(e => e.TotalTime)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_TIME");
            entity.Property(e => e.UnitName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("UNIT_NAME");
            entity.Property(e => e.UnitOwner)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("UNIT_OWNER");
            entity.Property(e => e.UnitTimestamp)
                .HasColumnType("DATE")
                .HasColumnName("UNIT_TIMESTAMP");
            entity.Property(e => e.UnitType)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("UNIT_TYPE");

            entity.HasOne(d => d.Run).WithMany(p => p.PlsqlProfilerUnits)
                .HasForeignKey(d => d.Runid)
                .HasConstraintName("SYS_C008062");
        });

        modelBuilder.Entity<QuestSlTempExplain1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("QUEST_SL_TEMP_EXPLAIN1");

            entity.Property(e => e.AccessPredicates)
                .IsUnicode(false)
                .HasColumnName("ACCESS_PREDICATES");
            entity.Property(e => e.Bytes)
                .HasColumnType("NUMBER")
                .HasColumnName("BYTES");
            entity.Property(e => e.Cardinality)
                .HasColumnType("NUMBER")
                .HasColumnName("CARDINALITY");
            entity.Property(e => e.Cost)
                .HasColumnType("NUMBER")
                .HasColumnName("COST");
            entity.Property(e => e.CpuCost)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CPU_COST");
            entity.Property(e => e.Depth)
                .HasColumnType("NUMBER")
                .HasColumnName("DEPTH");
            entity.Property(e => e.Distribution)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISTRIBUTION");
            entity.Property(e => e.FilterPredicates)
                .IsUnicode(false)
                .HasColumnName("FILTER_PREDICATES");
            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.IoCost)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("IO_COST");
            entity.Property(e => e.ObjectAlias)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasColumnName("OBJECT_ALIAS");
            entity.Property(e => e.ObjectInstance)
                .HasColumnType("NUMBER")
                .HasColumnName("OBJECT_INSTANCE");
            entity.Property(e => e.ObjectName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OBJECT_NAME");
            entity.Property(e => e.ObjectNode)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("OBJECT_NODE");
            entity.Property(e => e.ObjectOwner)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OBJECT_OWNER");
            entity.Property(e => e.ObjectType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OBJECT_TYPE");
            entity.Property(e => e.Operation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OPERATION");
            entity.Property(e => e.Optimizer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OPTIMIZER");
            entity.Property(e => e.Options)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OPTIONS");
            entity.Property(e => e.Other)
                .HasColumnType("LONG")
                .HasColumnName("OTHER");
            entity.Property(e => e.OtherTag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OTHER_TAG");
            entity.Property(e => e.ParentId)
                .HasColumnType("NUMBER")
                .HasColumnName("PARENT_ID");
            entity.Property(e => e.PartitionId)
                .HasColumnType("NUMBER")
                .HasColumnName("PARTITION_ID");
            entity.Property(e => e.PartitionStart)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PARTITION_START");
            entity.Property(e => e.PartitionStop)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PARTITION_STOP");
            entity.Property(e => e.PlanId)
                .HasColumnType("NUMBER")
                .HasColumnName("PLAN_ID");
            entity.Property(e => e.Position)
                .HasColumnType("NUMBER")
                .HasColumnName("POSITION");
            entity.Property(e => e.Remarks)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.SearchColumns)
                .HasColumnType("NUMBER")
                .HasColumnName("SEARCH_COLUMNS");
            entity.Property(e => e.StatementId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("STATEMENT_ID");
            entity.Property(e => e.TempSpace)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TEMP_SPACE");
            entity.Property(e => e.Timestamp)
                .HasColumnType("DATE")
                .HasColumnName("TIMESTAMP");
        });

        modelBuilder.Entity<TempEslEmployeesP>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEMP_ESL_EMPLOYEES_PS");

            entity.Property(e => e.AcctCd)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ACCT_CD");
            entity.Property(e => e.Asofdate)
                .HasColumnType("DATE")
                .HasColumnName("ASOFDATE");
            entity.Property(e => e.County)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("COUNTY");
            entity.Property(e => e.Deptid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPTID");
            entity.Property(e => e.Deptname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DEPTNAME");
            entity.Property(e => e.DeptnameAbbrv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPTNAME_ABBRV");
            entity.Property(e => e.Descr)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DESCR");
            entity.Property(e => e.DescrPosition)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DESCR_POSITION");
            entity.Property(e => e.DummyField)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DUMMY_FIELD");
            entity.Property(e => e.EmailAddr)
                .HasMaxLength(41)
                .IsUnicode(false)
                .HasColumnName("EMAIL_ADDR");
            entity.Property(e => e.EmplClass)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("EMPL_CLASS");
            entity.Property(e => e.Emplid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("EMPLID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.FullPartTime)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FULL_PART_TIME");
            entity.Property(e => e.Grade)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("GRADE");
            entity.Property(e => e.HireDt)
                .HasColumnType("DATE")
                .HasColumnName("HIRE_DT");
            entity.Property(e => e.Jobcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("JOBCODE");
            entity.Property(e => e.Jobtitle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("JOBTITLE");
            entity.Property(e => e.JobtitleAbbrv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("JOBTITLE_ABBRV");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.MBranch)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("M_BRANCH");
            entity.Property(e => e.MBranchDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_BRANCH_DESC");
            entity.Property(e => e.MConflictIntrst)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("M_CONFLICT_INTRST");
            entity.Property(e => e.MDivision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("M_DIVISION");
            entity.Property(e => e.MDivisionDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_DIVISION_DESC");
            entity.Property(e => e.MEtsTimekeeper)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("M_ETS_TIMEKEEPER");
            entity.Property(e => e.MEtsTimekprGrp)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("M_ETS_TIMEKPR_GRP");
            entity.Property(e => e.MReviewCycle)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("M_REVIEW_CYCLE");
            entity.Property(e => e.MSection)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("M_SECTION");
            entity.Property(e => e.MSectionDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_SECTION_DESC");
            entity.Property(e => e.MUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("M_UNIT");
            entity.Property(e => e.MUnitCouncil)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("M_UNIT_COUNCIL");
            entity.Property(e => e.MUnitDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("M_UNIT_DESC");
            entity.Property(e => e.MUnitGroup)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("M_UNIT_GROUP");
            entity.Property(e => e.MWorkSchedule)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("M_WORK_SCHEDULE");
            entity.Property(e => e.MailDrop)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAIL_DROP");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.NamePrefix)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("NAME_PREFIX");
            entity.Property(e => e.OrigHireDt)
                .HasColumnType("DATE")
                .HasColumnName("ORIG_HIRE_DT");
            entity.Property(e => e.PerOrg)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PER_ORG");
            entity.Property(e => e.PoiType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("POI_TYPE");
            entity.Property(e => e.PositionNbr)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("POSITION_NBR");
            entity.Property(e => e.Postal)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("POSTAL");
            entity.Property(e => e.PreferredName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PREFERRED_NAME");
            entity.Property(e => e.RegTemp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("REG_TEMP");
            entity.Property(e => e.RehireDt)
                .HasColumnType("DATE")
                .HasColumnName("REHIRE_DT");
            entity.Property(e => e.ReportsTo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("REPORTS_TO");
            entity.Property(e => e.SalAdminPlan)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SAL_ADMIN_PLAN");
            entity.Property(e => e.ServiceDt)
                .HasColumnType("DATE")
                .HasColumnName("SERVICE_DT");
            entity.Property(e => e.SupervisorId)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("SUPERVISOR_ID");
            entity.Property(e => e.TempFld)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEMP_FLD");
            entity.Property(e => e.TempFld2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEMP_FLD2");
            entity.Property(e => e.TempFld3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEMP_FLD3");
            entity.Property(e => e.TempFld4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEMP_FLD4");
            entity.Property(e => e.UnionCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("UNION_CD");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("WORK_PHONE");
        });

        modelBuilder.Entity<ToadPlanSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TOAD_PLAN_SQL");

            entity.HasIndex(e => e.StatementId, "TPSQL_IDX").IsUnique();

            entity.Property(e => e.Statement)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("STATEMENT");
            entity.Property(e => e.StatementId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("STATEMENT_ID");
            entity.Property(e => e.Timestamp)
                .HasColumnType("DATE")
                .HasColumnName("TIMESTAMP");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<ToadPlanTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TOAD_PLAN_TABLE");

            entity.HasIndex(e => e.StatementId, "TPTBL_IDX");

            entity.Property(e => e.Bytes)
                .HasColumnType("NUMBER")
                .HasColumnName("BYTES");
            entity.Property(e => e.Cardinality)
                .HasColumnType("NUMBER")
                .HasColumnName("CARDINALITY");
            entity.Property(e => e.Cost)
                .HasColumnType("NUMBER")
                .HasColumnName("COST");
            entity.Property(e => e.Distribution)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DISTRIBUTION");
            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.ObjectInstance)
                .HasColumnType("NUMBER")
                .HasColumnName("OBJECT_INSTANCE");
            entity.Property(e => e.ObjectName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OBJECT_NAME");
            entity.Property(e => e.ObjectNode)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("OBJECT_NODE");
            entity.Property(e => e.ObjectOwner)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OBJECT_OWNER");
            entity.Property(e => e.ObjectType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OBJECT_TYPE");
            entity.Property(e => e.Operation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OPERATION");
            entity.Property(e => e.Optimizer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OPTIMIZER");
            entity.Property(e => e.Options)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OPTIONS");
            entity.Property(e => e.Other)
                .HasColumnType("LONG")
                .HasColumnName("OTHER");
            entity.Property(e => e.OtherTag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OTHER_TAG");
            entity.Property(e => e.ParentId)
                .HasColumnType("NUMBER")
                .HasColumnName("PARENT_ID");
            entity.Property(e => e.PartitionId)
                .HasColumnType("NUMBER")
                .HasColumnName("PARTITION_ID");
            entity.Property(e => e.PartitionStart)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PARTITION_START");
            entity.Property(e => e.PartitionStop)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PARTITION_STOP");
            entity.Property(e => e.Position)
                .HasColumnType("NUMBER")
                .HasColumnName("POSITION");
            entity.Property(e => e.Remarks)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.SearchColumns)
                .HasColumnType("NUMBER")
                .HasColumnName("SEARCH_COLUMNS");
            entity.Property(e => e.StatementId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("STATEMENT_ID");
            entity.Property(e => e.Timestamp)
                .HasColumnType("DATE")
                .HasColumnName("TIMESTAMP");
        });

        modelBuilder.Entity<ViewAlleventsCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_CURRENT");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewAlleventsFacilno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_FACILNOS");

            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
        });

        modelBuilder.Entity<ViewAlleventsLogtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_LOGTYPES");

            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
        });

        modelBuilder.Entity<ViewAlleventsRelatedto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_RELATEDTO");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewAlleventsSearch>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_SEARCH");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewClearanceAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCE_ALL");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewClearanceOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCE_OUTSTANDING");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewClearanceissue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCEISSUES");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Clearancetype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPE");
            entity.Property(e => e.Clearancezone)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEZONE");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Creator)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("CREATOR");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Issuedby)
                .HasPrecision(7)
                .HasColumnName("ISSUEDBY");
            entity.Property(e => e.Issueddate)
                .HasColumnType("DATE")
                .HasColumnName("ISSUEDDATE");
            entity.Property(e => e.Issuedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ISSUEDTIME");
            entity.Property(e => e.Issuedto)
                .HasPrecision(7)
                .HasColumnName("ISSUEDTO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operator)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("OPERATOR");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasedto)
                .HasPrecision(7)
                .HasColumnName("RELEASEDTO");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Worktobeperformed)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("WORKTOBEPERFORMED");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewClearanceissuesCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCEISSUES_CURRENT");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Clearancetype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPE");
            entity.Property(e => e.Clearancezone)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEZONE");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Issuedby)
                .HasPrecision(7)
                .HasColumnName("ISSUEDBY");
            entity.Property(e => e.Issueddate)
                .HasColumnType("DATE")
                .HasColumnName("ISSUEDDATE");
            entity.Property(e => e.Issuedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ISSUEDTIME");
            entity.Property(e => e.Issuedto)
                .HasPrecision(7)
                .HasColumnName("ISSUEDTO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasedto)
                .HasPrecision(7)
                .HasColumnName("RELEASEDTO");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Worktobeperformed)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("WORKTOBEPERFORMED");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewClearancetype>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCETYPES");

            entity.Property(e => e.Clearancetype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPE");
            entity.Property(e => e.Clearancetypename)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPENAME");
            entity.Property(e => e.Clearancetypeno)
                .HasPrecision(2)
                .HasColumnName("CLEARANCETYPENO");
        });

        modelBuilder.Entity<ViewEosAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_EOS_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewEosCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_EOS_CURRENT");

            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Reportedby)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.Reporteddate)
                .HasColumnType("DATE")
                .HasColumnName("REPORTEDDATE");
            entity.Property(e => e.Reportedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REPORTEDTIME");
            entity.Property(e => e.Reportedto)
                .HasPrecision(7)
                .HasColumnName("REPORTEDTO");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsinstalled)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSINSTALLED");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewEosOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_EOS_OUTSTANDING");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewFlowchangeAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_FLOWCHANGE_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewFlowchangePresched>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_FLOWCHANGE_PRESCHED");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewFlowchangesCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_FLOWCHANGES_CURRENT");

            entity.Property(e => e.Accepted)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ACCEPTED");
            entity.Property(e => e.Changeby)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHANGEBY");
            entity.Property(e => e.Changebyunit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHANGEBYUNIT");
            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Meterid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("METERID");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Newvalue)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("NEWVALUE");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Offtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("OFFTIME");
            entity.Property(e => e.Oldunit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OLDUNIT");
            entity.Property(e => e.Oldvalue)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("OLDVALUE");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Requestedby)
                .HasPrecision(7)
                .HasColumnName("REQUESTEDBY");
            entity.Property(e => e.Requesteddate)
                .HasColumnType("DATE")
                .HasColumnName("REQUESTEDDATE");
            entity.Property(e => e.Requestedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REQUESTEDTIME");
            entity.Property(e => e.Requestedto)
                .HasPrecision(7)
                .HasColumnName("REQUESTEDTO");
            entity.Property(e => e.Seqno)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UNIT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewGeneralAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_GENERAL_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewGeneralCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_GENERAL_CURRENT");

            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Details)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Reportedby)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.Seqno)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewGeneralOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_GENERAL_OUTSTANDING");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewRealtime>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_REALTIME");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewSearchAllevent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SEARCH_ALLEVENTS");

            entity.Property(e => e.Clearanceid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLEARANCEID");
            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewSocAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SOC_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewSocCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SOC_CURRENT");

            entity.Property(e => e.Createdby)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Equipmentinvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Facilabbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Limitations)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("LIMITATIONS");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Modifiedby)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifyflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Notifiedfacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            entity.Property(e => e.Notifiedperson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            entity.Property(e => e.Operatorid)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Relatedto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            entity.Property(e => e.Releasedby)
                .HasPrecision(7)
                .HasColumnName("RELEASEDBY");
            entity.Property(e => e.Releaseddate)
                .HasColumnType("DATE")
                .HasColumnName("RELEASEDDATE");
            entity.Property(e => e.Releasedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RELEASEDTIME");
            entity.Property(e => e.Releasedto)
                .HasPrecision(7)
                .HasColumnName("RELEASEDTO");
            entity.Property(e => e.Releasetype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.Reportedby)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.Reporteddate)
                .HasColumnType("DATE")
                .HasColumnName("REPORTEDDATE");
            entity.Property(e => e.Reportedtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REPORTEDTIME");
            entity.Property(e => e.Reportedto)
                .HasPrecision(7)
                .HasColumnName("REPORTEDTO");
            entity.Property(e => e.Seqno)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.Shiftno)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Tagsremoved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSREMOVED");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.Workorders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewSocOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SOC_OUTSTANDING");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.Eventdate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventidRevno)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.Eventtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Facilname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Operatortype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Scandocsno)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Updatedate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewWorkorder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_WORKORDERS");

            entity.Property(e => e.Eventid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.Facilno)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Logtypeno)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            entity.Property(e => e.WoNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WO_NO");
        });
        modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
