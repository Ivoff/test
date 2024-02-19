namespace Application;

public interface ICommandHandler<T, U>
{
     U Handle(T command, CancellationToken cancellationToken);
}