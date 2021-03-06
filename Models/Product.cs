using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace productsAndCategories.Models;

public class Product 
{
    [Key]
    public int ProductId{get;set;}

    [Required]
    public string Name{get;set;}

    [Required]
    public string Description{get;set;}

    [Required]
    public int Price{get;set;}

    public List<Relationship> allCategories {get;set;} = new List<Relationship>();

    public DateTime CreatedAt{get;set;}=DateTime.Now;
    public DateTime UpdatedAt{get;set;}=DateTime.Now;


}