namespace Application.Interfaces.IRepositories
{
    public interface IEmpRoleRepository
    {
        public Task<string?> GetRole(string userID, int? facilNo);

        public bool IsInRole(string userID, string role, int? facilNo);
    }
}
