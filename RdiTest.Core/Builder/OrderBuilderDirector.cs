using FluentResults;

namespace Core.Builder;

/*
 * This is the general order builder, it does not make much sense since we only have one variation of the "Order" object.
 * But it would make sense if it was extended to support discrete orders like combos of sort.
 */

public class OrderBuilderDirector<T> where T: IOrderBuilder, new()
{
    public required T Builder { get; init; }

    public OrderBuilderDirector()
    {
        Builder = new T();
    }
}