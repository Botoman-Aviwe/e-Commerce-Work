namespace Log_In.Data.Base
{
    public class EntityBaseRepository<T>: IEntityBaseRepository where T : class,IEntityBase, new()
    {
    }
}
