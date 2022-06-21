using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace productsAndCategories.Models;

public class Category
{
    [Key]
    public int CategoryId {get;set;}

    [Required]
    public string Name{get;set;}

    public List<Relationship> allProducts {get;set;} = new List<Relationship>();


    public DateTime CreatedAt{get;set;}=DateTime.Now;
    public DateTime UpdatedAt{get;set;}=DateTime.Now;
}