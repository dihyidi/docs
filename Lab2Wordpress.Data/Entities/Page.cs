namespace Lab2Wordpress.Data.Entities;

public class Page : IEntity
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string Template { get; set; }
    public Media Attachment { get; set; }
}