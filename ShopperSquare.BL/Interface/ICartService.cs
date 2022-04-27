using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.BL.Interface
{
    public interface ICartService
    {
        public Task<bool> AddItemInCart(int itemId);
        public Task<bool> RemoveItemInCart(int itemId);
        public IQueryable<CartGetBL> GetCarts();
        public Task<bool> CheckOut();
    }
}
