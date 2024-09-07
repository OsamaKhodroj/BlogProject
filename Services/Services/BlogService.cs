using Entities.Domains;
using Entities.Enum;
using Entities.Interfaes;
using Microsoft.EntityFrameworkCore;

namespace Services.Services;

public class BlogService : IBlog
{
    private readonly BlogDbContext _blogDbContext;

    public BlogService(BlogDbContext blogDbContext)
    {
        _blogDbContext = blogDbContext;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="article"></param>
    /// <returns></returns>
    public async Task<OpStatus> Add(Article article)
    {
        try
        {
            await _blogDbContext.AddAsync(article);
            await _blogDbContext.SaveChangesAsync();
            return OpStatus.Success;
        }
        catch (Exception)
        {
            return OpStatus.Error;
        }
    }
     
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<OpStatus> Delete(int id)
    {
        try
        {
            var blog = await _blogDbContext.Set<Article>().FirstOrDefaultAsync(q => q.Id == id);
            if (blog != null)
            {
                _blogDbContext.Set<Article>().Remove(blog);
                await _blogDbContext.SaveChangesAsync();
                return OpStatus.Success;
            }
            return OpStatus.Error;
        }
        catch (Exception)
        {
            return OpStatus.Error;
        }
    }
     
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<Article>> List()
    {
        try
        {
            var list = await _blogDbContext.Set<Article>()
                .AsNoTracking()
                .ToListAsync();

            return list;
        }
        catch (Exception)
        { 
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public async Task<List<Article>> ListByCategoryId(int categoryId)
    {
        try
        {
            var list = await _blogDbContext.Set<Article>()
              .Where(q => q.CategoryId == categoryId)
              .AsNoTracking()
              .ToListAsync();

            return list;
        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<List<Article>> Search(string query)
    {
        try
        {
            var list = await _blogDbContext.Set<Article>()
            .Where(q => q.Title.ToLower().Contains(query.ToLower()))
            .AsNoTracking()
            .ToListAsync();
            return list;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="article"></param>
    /// <returns></returns>
    public async Task<OpStatus> Update(Article article)
    {
        try
        {
            await Task.CompletedTask;

            _blogDbContext.Update(article);
            _blogDbContext.SaveChanges();
            return OpStatus.Success;
        }
        catch (Exception)
        {
            return OpStatus.Error;
        }
    }
}
