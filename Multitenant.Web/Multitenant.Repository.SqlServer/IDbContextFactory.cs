namespace Multitenant.Repository.SqlServer
{
    public interface IDbContextFactory
    {
        string TenantConnection { get; set; }

        CRMContext Create();
    }
}
