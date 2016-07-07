namespace CRM.QueryModel
{
  public interface IQueryHandler<TQuery, TResponse>
  {
    TResponse Query(TQuery query);
  }

  public interface IQueryHandler<TResponse>
  {
    TResponse Query();
  }
}