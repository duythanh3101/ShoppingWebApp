namespace ShoppingWebApp.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T ownerId { get; set; }
    }
}
