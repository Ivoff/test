namespace Core.Error;

public abstract class ErrorDict<T, U>
{
    public U this[T key]
    {
        get => GetValue(key);
        set => SetValue(key, value);
    }

    protected abstract U GetValue(T key);
    protected abstract void SetValue(T key, U value);
}

