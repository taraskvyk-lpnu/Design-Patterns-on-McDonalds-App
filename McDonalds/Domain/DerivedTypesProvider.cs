using System.Reflection;

public class DerivedTypesProvider
{
    public static List<Type> GetLowDifficultyTypes(Type baseType)
    {
        Random random = new Random();
        List<Type> allTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(baseType) && !t.IsAbstract).ToList();
    
        List<Type> randomTypes = allTypes.OrderBy(x => random.Next()).Take(2).ToList();
        return randomTypes;
    }
    
    public static List<Type> GetMediumDifficultyTypes(Type baseType)
    {
        Random random = new Random();
        List<Type> allTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(baseType) && !t.IsAbstract).ToList();
    
        List<Type> randomTypes = allTypes.OrderBy(x => random.Next()).Take(Math.Max(1, GetHardDifficultyTypes(baseType).Count / 2 + 1)).ToList();
    
        return randomTypes;
    }
    
    public static List<Type> GetHardDifficultyTypes(Type baseType)
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(baseType) && !t.IsAbstract)
            .ToList();
    }
}