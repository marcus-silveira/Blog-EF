namespace Blog.Models;

public class Category
{
    public int Id { get; }
    public string Name { get; set; }
    public string Slug { get; set; }

    public List<Post> Posts { get; set; }
}