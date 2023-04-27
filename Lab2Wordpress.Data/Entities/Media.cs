namespace Lab2Wordpress.Data.Entities;

public class Media : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string FileType { get; set; }
    public string Url { get; set; }
    public string Alt { get; set; }
}