using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class Category
{
    [Key] public int Id { get; }

    public string Name { get; set; }
    public string Slug { get; set; }
}