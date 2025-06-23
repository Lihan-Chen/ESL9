using Application.Dtos;
using Core.Models.BusinessEntities;

namespace Application.Interfaces.IRepositories
{
    public interface IFacilityRepository 
    {
        public IOrderedQueryable<Facility> GetAll();
        
        public IQueryable<Facility> GetFacility(int? FacilNo);

        public IQueryable<Facility> GetFacility(string FacilName);

        public Task<string?> GetFacilName(int? FacilNo);

        public Task<int?> GetFacilNo(string? FacilName);

        public IOrderedQueryable<Facility> GetFacilities();

        public IOrderedQueryable<FacilDto> GetFacilList();

        public IQueryable<string> GetFacilTypeList();
    }

}