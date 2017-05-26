using System.Data;
using System.Threading.Tasks;

namespace app_less_leaky.Repositories
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}