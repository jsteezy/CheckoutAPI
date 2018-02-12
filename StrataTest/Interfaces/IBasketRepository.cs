using StrataTest.Models;

namespace StrataTest.Interfaces
{
    public interface IBasketRepository
    {
        Basket AddItem(int productId);

        Basket RemoveItem(int productId);

        void AddUser(User user);
    }
}