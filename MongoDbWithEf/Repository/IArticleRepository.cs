using Microsoft.AspNetCore.Mvc;
using MongoDbWithEf.Data;

namespace MongoDbWithEf.Repository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> Get();
        Task<Article> Get(string id);
        Task<Article>  Post([FromBody] Article article);
        Task<bool> Put(string id, [FromBody] Article article);
        Task<bool> Delete(string id);
    }
}
