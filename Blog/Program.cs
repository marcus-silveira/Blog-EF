using Blog.Data;
using Blog.Models;

namespace Blog;

internal class Program
{
    private static void Main(string[] args)
    {
        using var context = new BlogDataContext();
        var category = new Category
        {
            Name = "ASP.NET",
            Slug = "asp-net"
        };

        context.Categories.Add(category);
        context.SaveChanges();
    }
}