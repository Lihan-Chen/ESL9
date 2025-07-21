using Microsoft.EntityFrameworkCore;
using Core.Models.BusinessEntities;

namespace Infrastructure.DataAccess;

public partial class EslViewContext : DbContext //, IEslViewContext
{
    public EslViewContext()
    {
    }

    public EslViewContext(DbContextOptions<EslViewContext> options)
        : base(options)
    {
    }

    #region Business Entities

    #endregion Business Entities

    #region Business Views

    public virtual DbSet<ViewAllEventsCurrent> Current_AllEvents { get; set; }

    public virtual DbSet<ViewAllEventsFacilNo> AllEvents_FacilNos { get; set; }

    public virtual DbSet<ViewAllEventsLogType> AllEvents_LogTypes { get; set; }

    public virtual DbSet<ViewAllEventsRelatedTo> Related_AllEvents { get; set; }

    public virtual DbSet<ViewAllEventsSearch> AllEvents_Search { get; set; }

    public virtual DbSet<ViewClearanceAll> All_Clearances { get; set; }

    public virtual DbSet<ViewClearanceOutstanding> Outstanding_Clearances { get; set; }

    public virtual DbSet<ViewClearanceIssue> All_ClearanceIssues { get; set; }

    public virtual DbSet<ViewClearanceIssuesCurrent> Current_ClearanceIssues { get; set; }

    public virtual DbSet<ViewClearanceType> Clearance_Types { get; set; }

    public virtual DbSet<ViewEOSAll> All_EOS { get; set; }

    public virtual DbSet<ViewEOSCurrent> Current_EOS { get; set; }

    public virtual DbSet<ViewEOSOutstanding> Outstanding_EOS { get; set; }

    public virtual DbSet<ViewFlowChangeAll> All_FlowChanges { get; set; }

    public virtual DbSet<ViewFlowChangePresched> Presched_FlowChanges { get; set; }

    public virtual DbSet<ViewFlowChangesCurrent> Current_FlowChanges { get; set; }

    public virtual DbSet<ViewGeneralAll> All_General { get; set; }

    public virtual DbSet<ViewGeneralCurrent> Current_General { get; set; }

    public virtual DbSet<ViewGeneralOutstanding> Outstanding_General { get; set; }

    public virtual DbSet<ViewRealTime> RealTime_FlowChangess { get; set; }

    // Same as AllEvents_Search
    public virtual DbSet<ViewSearchAllEvent> Search_AllEvents { get; set; }

    public virtual DbSet<ViewSOCAll> All_SOC { get; set; }

    public virtual DbSet<ViewSOCCurrent> Current_SOC { get; set; }

    public virtual DbSet<ViewSOCOutstanding> Outstanding_SOC { get; set; }

    public virtual DbSet<ViewWorkOrder> Work_Orders { get; set; }

    #endregion Business Views

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseOracle("Data Source=odev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ESL")
            .UseCollation("USING_NLS_COMP");

        #region Business Entity Builders

        #endregion Business Entity Builders

        modelBuilder.Entity<ViewAllEventsCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_CURRENT");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewAllEventsFacilNo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_FACILNOS");

            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
        });

        modelBuilder.Entity<ViewAllEventsLogType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_LOGTYPES");

            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
        });

        modelBuilder.Entity<ViewAllEventsRelatedTo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_RELATEDTO");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewAllEventsSearch>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_ALLEVENTS_SEARCH");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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

        modelBuilder.Entity<ViewClearanceAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCE_ALL");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewClearanceOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCE_OUTSTANDING");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewClearanceIssue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCEISSUES");

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
            entity.Property(e => e.Creator)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("CREATOR");
            entity.Property(e => e.EquipmentInvolved)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
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
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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
            entity.Property(e => e.Operator)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("OPERATOR");
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

        modelBuilder.Entity<ViewClearanceIssuesCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCEISSUES_CURRENT");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
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
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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

        modelBuilder.Entity<ViewClearanceType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CLEARANCETYPES");

            entity.Property(e => e.ClearanceType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPE");
            entity.Property(e => e.ClearanceTypeName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CLEARANCETYPENAME");
            entity.Property(e => e.ClearanceTypeNo)
                .HasPrecision(2)
                .HasColumnName("CLEARANCETYPENO");
        });

        modelBuilder.Entity<ViewEOSAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_EOS_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewEOSCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_EOS_CURRENT");

            entity.Property(e => e.CreatedBy)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.EquipmentInvolved)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTINVOLVED");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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
            entity.Property(e => e.ReleaseType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.ReportedBy)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.ReportedDate)
                .HasColumnType("DATE")
                .HasColumnName("REPORTEDDATE");
            entity.Property(e => e.ReportedTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REPORTEDTIME");
            entity.Property(e => e.ReportedTo)
                .HasPrecision(7)
                .HasColumnName("REPORTEDTO");
            entity.Property(e => e.SeqNo)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.ShiftNo)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.TagsInstalled)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TAGSINSTALLED");
            entity.Property(e => e.TagsRemoved)
                .HasMaxLength(100)
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
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewEOSOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_EOS_OUTSTANDING");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewFlowChangeAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_FLOWCHANGE_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewFlowChangePresched>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_FLOWCHANGE_PRESCHED");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewFlowChangesCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_FLOWCHANGES_CURRENT");

            entity.Property(e => e.Accepted)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ACCEPTED");
            entity.Property(e => e.ChangeBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHANGEBY");
            entity.Property(e => e.ChangeByUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHANGEBYUNIT");
            entity.Property(e => e.CreatedBy)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.MeterID)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("METERID");
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
            entity.Property(e => e.NewValue)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("NEWVALUE");
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
            entity.Property(e => e.OffTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("OFFTIME");
            entity.Property(e => e.OldUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OLDUNIT");
            entity.Property(e => e.OldValue)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("OLDVALUE");
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
            entity.Property(e => e.RequestedBy)
                .HasPrecision(7)
                .HasColumnName("REQUESTEDBY");
            entity.Property(e => e.RequestedDate)
                .HasColumnType("DATE")
                .HasColumnName("REQUESTEDDATE");
            entity.Property(e => e.RequestedTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REQUESTEDTIME");
            entity.Property(e => e.RequestedTo)
                .HasPrecision(7)
                .HasColumnName("REQUESTEDTO");
            entity.Property(e => e.SeqNo)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            entity.Property(e => e.ShiftNo)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UNIT");
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
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewGeneralCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_GENERAL_CURRENT");

            entity.Property(e => e.CreatedBy)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Details)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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
            entity.Property(e => e.ReportedBy)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.SeqNo)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            entity.Property(e => e.ShiftNo)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
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
            entity.Property(e => e.WorkOrders)
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
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewRealTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_REALTIME");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewSearchAllEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SEARCH_ALLEVENTS");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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

        modelBuilder.Entity<ViewSOCAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SOC_ALL");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewSOCCurrent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SOC_CURRENT");

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
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.FacilAbbr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("FACILABBR");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
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
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RELEASETYPE");
            entity.Property(e => e.ReportedBy)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            entity.Property(e => e.ReportedDate)
                .HasColumnType("DATE")
                .HasColumnName("REPORTEDDATE");
            entity.Property(e => e.ReportedTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("REPORTEDTIME");
            entity.Property(e => e.ReportedTo)
                .HasPrecision(7)
                .HasColumnName("REPORTEDTO");
            entity.Property(e => e.SeqNo)
                .HasPrecision(4)
                .HasColumnName("SEQNO");
            entity.Property(e => e.ShiftNo)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            entity.Property(e => e.TagsRemoved)
                .HasMaxLength(100)
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
            entity.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        });

        modelBuilder.Entity<ViewSOCOutstanding>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_SOC_OUTSTANDING");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            entity.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.FacilName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FACILNAME");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOGTYPENAME");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            entity.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            entity.Property(e => e.ScanDocsNo)
                .HasColumnType("NUMBER")
                .HasColumnName("SCANDOCSNO");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
        });

        modelBuilder.Entity<ViewWorkOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_WORKORDERS");

            entity.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            entity.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            entity.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
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
