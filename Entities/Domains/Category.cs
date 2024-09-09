
namespace Entities.Domains;

public class Category: BaseClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }

    public ICollection<Article> Articles { get; set; }
}
