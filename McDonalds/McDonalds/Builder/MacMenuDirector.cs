namespace McDonalds.MacMenuBuilder;

public class MacMenuDirector
{
    public MacMenuBuilder Builder { get; set; }
    
    public void Construct()
    {
        Builder.BuildBurger();
        Builder.BuildDrink();
        Builder.BuildSideDish();
    }
}