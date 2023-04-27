using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Wordpress.Data.Entities;

public interface IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}