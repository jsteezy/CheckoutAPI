using StrataTest.Models;

namespace StrataTest.Interfaces
{
    public interface IBasketRepository
    {
        BasketModel AddItem(int productId);

        BasketModel RemoveItem(int productId);

        void AddUser(UserModel userModel);
    }
}