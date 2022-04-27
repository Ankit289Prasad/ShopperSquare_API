using ShopperSquare.BL.Interface;
using ShopperSquare.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.BL.Implementation
{
    public class CartService : ICartService
    {
        private readonly IRepo _repo;

        public CartService(IRepo repo)
        {
            _repo = repo;
        }

        public Task<bool> AddItemInCart(int itemId)
        {
            return _repo.AddItemInCart(itemId);
        }

        public Task<bool> RemoveItemInCart(int itemId)
        {
            return _repo.RemoveItemInCart(itemId);
        }

        public IQueryable<CartGetBL> GetCarts()
        {
            var cartEntity = _repo.GetCarts();
            var getList = new List<CartGetBL>();
            if (cartEntity != null)
            {
                foreach (var item in cartEntity)
                {
                    getList.Add(new CartGetBL
                    {
                        ProductName = item.ProductName,
                        Image = item.Image,
                        MRPAmount = item.MRPAmount,
                        DiscountAmount = item.DiscountAmount,
                        Quantity=item.Quantity
                    });
                }
            }
            return getList.AsQueryable();
        }

        public async Task<bool> CheckOut()
        {
            return await _repo.CheckOut();
        }
    }
}
