using ShoppingWebApp.Data.Enums;

namespace ShoppingWebApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
