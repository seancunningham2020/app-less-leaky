using System.Threading.Tasks;
using app_less_leaky.Models;

namespace app_less_leaky.Repositories
{
    public interface IAuthorsRepository
    {
        Task<PostResponse> AddAuthor(string name);
    }
}