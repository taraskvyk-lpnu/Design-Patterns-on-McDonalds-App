using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = 0;
    public string TypeName { get; set; }
    public string imageUrl { get; set; }

    public Image(string typeName, string imageUrl)
    {
        TypeName = typeName;
        this.imageUrl = imageUrl;
    }
}