namespace Core.Error.Order;

public record OrderErrorValue(
    Guid Id = default, 
    int KitchenAreaOrderIndex  = default, 
    int SaladOrderComponentIndex  = default,
    string ErrorSubject = ""
);