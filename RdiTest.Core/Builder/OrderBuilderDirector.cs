namespace Core.Builder;

public class OrderBuilderDirector
{
    public IOrderBuilder Builder { get; init; }

    private OrderBuilderDirector() { }

    public OrderBuilderDirector(IOrderBuilder builder)
    {
        Builder = builder;
    }
}