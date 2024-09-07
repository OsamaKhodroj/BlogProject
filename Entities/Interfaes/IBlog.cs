using Entities.Domains;
using Entities.Enum;

namespace Entities.Interfaes;

public interface IBlog
{
    Task<OpStatus> Add(Article article);
    Task<OpStatus> Update(Article article);
    Task<OpStatus> Delete(int id);
    Task<List<Article>> List();
    Task<List<Article>> ListByCategoryId(int categoryId);
    Task<List<Article>> Search(string query);
}
