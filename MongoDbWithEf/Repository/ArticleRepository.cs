using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbWithEf.Data;

namespace MongoDbWithEf.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MongoDbContext _context;

        public ArticleRepository(IOptions<MongoDbConfiguration> settings)
        {
            _context = new MongoDbContext(settings);
        }

        public async Task<bool> Delete(string id)
        {
            var article = await _context.Articles.Find(a => a.Id == id).FirstOrDefaultAsync();

            if (article == null)
            {
                return false;
            }

            await _context.Articles.DeleteOneAsync(a => a.Id == id);
            return true;
        }

        public async Task<IEnumerable<Article>> Get()
        {
            var articles = await _context.Articles.Find(_ => true).ToListAsync();
            return articles;
        }

        public async Task<Article> Get(string id)
        {
            var article = await _context.Articles.Find(a => a.Id == id).FirstOrDefaultAsync();

            return article;
        }

        public async Task<Article> Post([FromBody] Article article)
        {
            await _context.Articles.InsertOneAsync(article);
            return article;
        }

        public async Task<bool> Put(string id, [FromBody] Article article)
        {
            var existingArticle = await _context.Articles.Find(a => a.Id == id).FirstOrDefaultAsync();

            if (existingArticle == null)
            {
                return false;
            }
            article.Id = existingArticle.Id;
            await _context.Articles.ReplaceOneAsync(a => a.Id == id, article);
            return true;
        }
    }
}
