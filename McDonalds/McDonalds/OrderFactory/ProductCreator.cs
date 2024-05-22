namespace McDonalds.OrderFactory;

public class ProductCreator
{
    private static Random random = new Random();
    public static List<T> Create<T>(int count, List<Type> types) where T : class
    {
        var items = new List<T>();
        for (int i = 0; i < count; i++)
        {
            Type itemType = types[random.Next(types.Count)];
            if (Activator.CreateInstance(itemType) is T item)
                items.Add(item);
        }
        return items;
    }
}