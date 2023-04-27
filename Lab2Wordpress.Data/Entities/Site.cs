namespace Lab2Wordpress.Data.Entities;

public class Site : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public Theme Theme { get; set; }
    public IList<Page> Content { get; set; }
}