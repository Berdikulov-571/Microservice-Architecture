using Microsoft.EntityFrameworkCore;

namespace Autorization.Api.DataContexts
{
    public class KadastrDatabase : DbContext
    {
        public KadastrDatabase(DbContextOptions<KadastrDatabase> options) : base(options)
        {

        }
    }
}