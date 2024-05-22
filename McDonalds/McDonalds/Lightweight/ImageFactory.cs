using DataAccess;
using Domain;
using Domain.Entites;

namespace McDonalds.Lightweight;

public static class ImageFactory
{
    private static readonly Dictionary<Type, string> _images = new Dictionary<Type, string>();

    public static string GetImageUrl(Type type)
    {
        if (!_images.ContainsKey(type))
        {
            if (string.IsNullOrEmpty(type.Name))
            {
                return _images[type];
            }
            else
            {
                var imageFromDatabase = GetImageFromDatabase(type);
                _images[type] = imageFromDatabase.imageUrl;
            }
        }
        
        return _images[type];
    }

    private static Image GetImageFromDatabase(Type type)
    {
        var context = McDonaldsDbContext.Context;
        var image = context.Images.FirstOrDefault(i => i.TypeName == type.Name);
        return image;
    }
}