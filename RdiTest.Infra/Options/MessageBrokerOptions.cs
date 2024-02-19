namespace Infra.Options;

public class TopicsOptions
{
    public const string Topics = "MessageBroker.Topics";

    public string KitchenAreaFries { get; set; } = string.Empty;
    public string KitchenAreaGrill { get; set; } = string.Empty;
    public string KitchenAreaSalad { get; set; } = string.Empty;
    public string KitchenAreaDrink { get; set; } = string.Empty;
    public string KitchenAreaDessert { get; set; } = string.Empty;
}

public class MessageBrokerOptions
{
    public const string MessageBroker = "MessageBroker";

    public TopicsOptions Topics { get; set; }
    public string OrderBrokerEndpoint { get; set; } = string.Empty;
}