namespace Infra.Options;

public class QueuesOptions
{
    public const string SectionName = "Queues";

    public required string KitchenAreaFries { get; set; }
    public required string KitchenAreaGrill { get; set; }
    public required string KitchenAreaSalad { get; set; }
    public required string KitchenAreaDrink { get; set; }
    public required string KitchenAreaDessert { get; set; }
}