using QUERY.Contracts.Repositories;
using QUERY.Data;

namespace QUERY.Repositories
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private readonly AppDbContext dbContext;
        private IBlogRepository _blog;
        public RepositoryContainer(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IBlogRepository Blog
        {
            get
            {
                return _blog ??= new BlogRepository(dbContext);
            }
        }

        public int SaveAllChanges()
        {
            return dbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
