namespace CRM.Application.Handlers
{
  public interface ICommandHandler<T>
  {
    void Handle(T command);
  }
}