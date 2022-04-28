using ShopperSquare.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.DL
{
    public interface IRepo
    {
        Task<bool> RegisterUser(User newUser);
        Task<bool> ValidLogin(string emailId, string password);
        Task<bool> GenerateResetPasswordCode(string emailId);
        Task<bool> ResetPasswordByCode(string emailId,string resetCode,string newPassword);

        Task<bool> AddItem(Item newItem);
        List<Item> GetItems();
        List<Item> GetItemsBasedOnCategory(string categoryName);
        List<Item> GetItemsByPartialNames(string partialName);

        Task<bool> AddItemInCart(int itemId);
        Task<bool> RemoveItemInCart(int itemId);
        List<CartDetails> GetCarts();
        Task<bool> CheckOut();

        List<Orders> GetOrders();
    }
}
