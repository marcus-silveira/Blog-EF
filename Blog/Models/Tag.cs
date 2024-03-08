namespace Blog.Models;

public class Tag
{
    public int Id { get; }
    public string Name { get; set; }
    public string Slug { get; set; }

    public List<Post> Posts { get; set; }
}