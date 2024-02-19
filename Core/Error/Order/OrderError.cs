using FluentResults;

namespace Core.Error.Order;

public class OrderError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }

    public OrderError(
        string message, 
        Guid Id,
        int KitchenAreaOrderIndex,
        int SaladOrderComponentIndex,
        string ErrorSubject)
    {
        Message = message;
        Metadata = new Dictionary<string, object>()
        {
            {"Id", Id},
            {"KitchenAreaOrderIndex", KitchenAreaOrderIndex},
            {"SaladOrderComponentIndex", SaladOrderComponentIndex},
            {"ErrorSubject", ErrorSubject},
        };
    }
}