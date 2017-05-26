using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using app_less_leaky.Models;
using Dapper;

namespace app_less_leaky.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly IDbConnectionFactory _database;
        
        public AuthorsRepository(IDbConnectionFactory database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async Task<PostResponse> AddAuthor(string name)
        {
            using (var connection = await _database.CreateConnectionAsync())
            {
                try {
                    await connection.ExecuteAsync(
                        "[AddAuthor]", 
                        new { Name = name }, 
                        commandType: CommandType.StoredProcedure);
                }
                catch (SqlException sqlException) when (sqlException.Number == 10001) {
                    return  PostResponse.AuthorAlreadyExists;
                }

                return PostResponse.Success;
            }
        }
    }
}