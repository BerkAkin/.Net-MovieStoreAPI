using Microsoft.EntityFrameworkCore;

namespace WebAPI.DBOperations
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }
    }
}