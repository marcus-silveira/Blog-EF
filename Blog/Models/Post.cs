namespace Blog.Models;

public class Post
{
    public int Id { get; private set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public  DateTime CreatedAt { get; set; }
    public  DateTime LastUpdateDateTime { get; set; }
}