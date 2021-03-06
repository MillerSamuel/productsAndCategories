using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace productsAndCategories.Models;

public class Relationship
{
    [Key]
    public int RelationshipId {get;set;}

    public int ProductId {get;set;}
    public Product? Product {get;set;}

    public int CategoryId {get;set;}
    public Category? Category {get;set;}
}
