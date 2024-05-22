using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public interface IImageFactory
{
    string GetImageUrl(Type type);
}