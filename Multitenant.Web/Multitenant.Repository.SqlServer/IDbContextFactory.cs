namespace Multitenant.Repository.SqlServer
{
    public interface IDbContextFactory
    {
        string TenantName { get; set; }

        CRMContext Create();
    }
}
