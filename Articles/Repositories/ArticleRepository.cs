using Articles.Domain;

namespace Articles.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}