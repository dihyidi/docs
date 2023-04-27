namespace Lab2Wordpress.Data.Entities;

public class Theme : IEntity
{
    public int Id { get; set; }
    public string PrimaryColor { get; set; }
    public string SecondaryColor { get; set; }
    public string Gradient { get; set; }
}