namespace Core.OrderRequest;

public record RequestPortionOrder
{
    public int PortionQuantity { get; init; }

    protected RequestPortionOrder(int portionQuantity)
    {
        PortionQuantity = portionQuantity;
    }
}

