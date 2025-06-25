using Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitofWork
    {
        Task SaveChangesAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken);

        // Add all IRepositories here
        //IUserRepository Users { get; }

        IEmployeeRepository Employees { get; }

        IEmpRoleRepository EmpRoles { get; }

        //IConstantRepository Constants { get; }

        //IMeterRepository Meters { get; }

        IAllEventRepository AllEvents { get; }

        IFacilityRepository Facilities { get; }

        ILogTypeRepository LogTypes { get; }

        //IClearanceIssueRepository ClearanceIssues { get; }

        //IClearanceTypeRepository ClearanceTypes { get; }

        //IClearanceZoneRepository ClearanceZones { get; }

        //IDetailsUserRepository DetailsList { get; }

        //IEOSRepository EOSLog { get; }

        //IEquipmentInvolvedRepository EquipmentInvolvedList { get; }

        //IFlowchangeRepository FlowChanges { get; }

        //IGeneralRepository GeneralLog { get; }

        //ILocationRepository Locations { get; }

        //IPlantShiftRepository PlantsShiftList { get; }

        //IRelatedToRepository RelatedToList { get; }

        //IScanDocRepository ScanDocs { get; }

        //IScanLobRepository ScanLobs { get; }

        //ISOCRepository SOClog { get; }

        //ISubjectRepository Subjects { get; }

        //IUnitRepository Units { get; }

        //IWorkOrderRepository WorkOrders { get; }

        //IWorkToBePerformedRepository WorkToBePerformedList { get; }

        // CompleteAsync can include additional business rules such as IAuditable Implementation
        Task CompleteAsync();

        //// Testing AppDbContext https://stackoverflow.com/questions/59753218/how-to-use-dbcontext-in-separate-class-library-net-core
        //IRepository<T> Repository<T>() where T : class;
        //Task SaveChangesAsync();
    }
}

    //public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly DbContext _dbContext;
    //    private Hashtable _repositories;
    //    public UnitOfWork(DbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public IRepository<T> Repository<T>() where T : class
    //    {
    //        if (_repositories == null)
    //            _repositories = new Hashtable();

    //        var type = typeof(T).Name;

    //        if (!_repositories.ContainsKey(type))
    //        {
    //            var repositoryType = typeof(Repository<>);

    //            var repositoryInstance =
    //                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

    //            _repositories.Add(type, repositoryInstance);
    //        }

    //        return (IRepository<T>)_repositories[type];
    //    }

    //    public async Task SaveChangesAsync()
    //    {
    //        await _dbContext.SaveChangesAsync();
    //    }
    //}

    //public interface IRepository<TEntity> where TEntity : class
    //{
    //    Task InsertEntityAsync(TEntity entity);
    //}

    //internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    //{
    //    private readonly DbContext _dbContext;
    //    public Repository(DbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public async Task InsertEntityAsync(TEntity entity)
    //    {
    //        await _dbContext.Set<TEntity>().AddAsync(entity);
    //    }
    //}

    // end of testing AppDbContext