using Application.Command.Messages;

namespace Application.Handler.OrderCommandHandler;

public record OrderCommandResult(
    List<string> ResultAddresses,
    List<CreateDessertOrderCommand> DessertOrderCommands,
    List<CreateFriesOrderCommand> FriesOrderCommands,
    List<CreateGrillOrderCommand> GrillOrderCommands,
    List<CreateDrinkOrderCommand> DrinkOrderCommands,
    List<CreateSaladOrderCommand> SaladOrderCommands
);


