
using System.ComponentModel.DataAnnotations;

namespace Entities.Domains;

public class Article : BaseClass
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }  
    public DateTime CreatedDate { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
