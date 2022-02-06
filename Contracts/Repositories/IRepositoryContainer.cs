namespace QUERY.Contracts.Repositories
{
    public interface IRepositoryContainer
    {
        public IBlogRepository Blog { get; }

        int SaveAllChanges();
    }
}
