using Application.Dtos;
using Application.Interfaces.IRepositories;
using Core.Models.BusinessEntities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class FacilityRepository(
            EslDbContext context,
            ILogger<FacilityRepository> logger
            ) : IFacilityRepository
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<FacilityRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<string?> GetFacilName(int? facilNo)
        {
            string? _facilName = null;

            if (facilNo == null || facilNo == 0)
            {
                throw new ArgumentNullException(nameof(facilNo), "Facility number cannot be null.");
            }
            
            _facilName = await this.GetFacility(facilNo).Select(s => s.FacilName).FirstOrDefaultAsync();
            _facilName = _facilName!.Split(' ').ElementAt(0).Trim();

            return _facilName;
        }

        public async Task<int?> GetFacilNo(string? facilName)
        {
            //var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            if (string.IsNullOrEmpty(facilName))
            {
                // return null;
                throw new ArgumentNullException(nameof(facilName), "Facility name cannot be null.");
            }

            return await this.GetFacility(facilName).Select(x => x.FacilNo).FirstOrDefaultAsync();          
        }

        public IOrderedQueryable<Facility> GetAll()
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            return query.OrderBy(f => f.FacilNo);
        }

        // GetItem(int facilNo)
        public IQueryable<Facility> GetFacility(int? facilNo)
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            if (facilNo is null || facilNo == 0)
            {
                throw new ArgumentNullException(nameof(facilNo), "Facility number cannot be null or 0.");
            }

            return query.Where(e => e.FacilNo == facilNo);
        }

        public IQueryable<Facility> GetFacility(string facilName)
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            if (string.IsNullOrEmpty(facilName))
            {
                // return null;
                throw new ArgumentNullException(nameof(facilName), "Facility name cannot be null.");
            }

            // case-insensitive search
            return query.Where(f => facilName.Contains(f.FacilName, StringComparison.CurrentCultureIgnoreCase));
        }

        public IOrderedQueryable<Facility> GetFacilities()
        {
            return _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y").OrderBy(f => f.FacilNo);
        }

        public IOrderedQueryable<FacilDto> GetFacilList()
        {
            var plantFacilTypes = new List<string> { "OCC", "DsOCC", "PP", "TP", "FP", "DVL" };

            return this.GetFacilities().Where(f => plantFacilTypes.Contains(f.FacilType))
                                       .Select(x => new FacilDto { FacilNo = x.FacilNo, FacilName = x.FacilName, FacilAbbr = x.FacilAbbr })
                                       .OrderBy(o => o.FacilNo);
        }

        public IQueryable<string> GetFacilTypeList() => this.GetFacilities().Select(x => x.FacilType).Distinct();


        //var _facilTypes = dbSet.Where(item => item != null).Select(f => f.FacilType).Distinct();
        //var _selectFacilTypes = _facilTypes.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
        //SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
        //_selectFacilTypes.Insert(0, _emptyString);
        //return _selectFacilTypes;

        //var _facilTypes =  await dbSet.Where(item => item != null).Distinct().ToListAsync();
        //var _selectFacilTypes = new SelectList(_facilTypes, "FacilType", "FacilType");
        //SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
        //_selectFacilTypes.Prepend(_emptyString);
        //return _selectFacilTypes;
        //
    }
}
