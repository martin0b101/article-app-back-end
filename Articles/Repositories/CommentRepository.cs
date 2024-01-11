using Articles.Domain;

namespace Articles.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}