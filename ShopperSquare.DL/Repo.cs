using ShopperSquare.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.DL
{
    public class Repo : IRepo
    {
        private readonly ApplicationDbContext _dbContext;

        static bool loginFlag = false;

        static User loginStatus = null;

        public Repo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterUser(User newUser)
        {
            _dbContext.Users.Add(newUser);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ResetPassword(string oldPassword, string newPassword, string emailId)
        {
            var resultUser = _dbContext.Users.FirstOrDefault(x => x.Password == oldPassword && x.EmailId == emailId);
            if (resultUser == null)
            {
                return false;
            }
            resultUser.Password = newPassword;
            var status = await _dbContext.SaveChangesAsync();
            if (status == 1)
            {
                loginFlag = false;
                return true;
            }
            return false;
        }

        public async Task<bool> ValidLogin(string emailId, string password)
        {
            loginStatus = _dbContext.Users.FirstOrDefault(x => x.EmailId == emailId && x.Password == password);

            if (loginStatus == null)
            {
                await _dbContext.DisposeAsync();
                return false;
            }
            loginFlag = true;
            return true;
        }


        public async Task<bool> AddItem(Item newItem)
        {
            _dbContext.Items.Add(newItem);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public List<Item> GetItems()
        {
            return _dbContext.Items.ToList();
        }

        public List<Item> GetItemsBasedOnCategory(string categoryName)
        {
            var resultEntity = _dbContext.Items.Where(
                x => x.CategoryId == (_dbContext.Categories.FirstOrDefault(y => y.Name == categoryName).Id));
            return resultEntity.ToList();
        }

        public List<Item> GetItemsByPartialNames(string partialName)
        {
            var resultEntity = _dbContext.Items.Where(
                x => x.Name.Contains(partialName));
            return resultEntity.ToList();
        }


        public async Task<bool> AddItemInCart(int itemId)
        {
            if (loginFlag && (loginStatus != null))
            {
                var item = _dbContext.Items.FirstOrDefault(x => x.Id == itemId);
                if (item.InStock)
                {
                    int userId = loginStatus.Id;
                    int amount = item.MRPAmount;
                    decimal discountAmount = amount - (amount * (item.DiscountPercentage) / 100);
                    int itemCount = 1;
                    var cartList = _dbContext.Carts.FirstOrDefault(x => x.ItemId == itemId && x.UserId == userId);
                    if (cartList != null)
                    {
                        cartList.ItemCount = cartList.ItemCount + itemCount;
                        cartList.MRPAmount = amount + cartList.MRPAmount;
                        cartList.DiscountAmount = discountAmount + cartList.DiscountAmount;
                    }
                    else
                    {
                        _dbContext.Carts.Add(new Cart
                        {
                            UserId = userId,
                            ItemId = itemId,
                            DiscountAmount = discountAmount,
                            ItemCount = itemCount,
                            MRPAmount = amount
                        });
                    }
                    var result = await _dbContext.SaveChangesAsync();
                    if (result == 1)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveItemInCart(int itemId)
        {
            if (loginFlag && (loginStatus != null))
            {
                var item = _dbContext.Items.FirstOrDefault(x => x.Id == itemId);

                int userId = loginStatus.Id;
                int amount = item.MRPAmount;
                decimal discountAmount = amount - (amount * (item.DiscountPercentage) / 100);
                int itemCount = 1;
                var cartList = _dbContext.Carts.FirstOrDefault(x => x.ItemId == itemId && x.UserId == userId);
                if (cartList != null)
                {
                    cartList.ItemCount = cartList.ItemCount - itemCount;
                    cartList.MRPAmount = cartList.MRPAmount - amount;
                    cartList.DiscountAmount = cartList.DiscountAmount - discountAmount;
                }
                else
                {
                    return false;
                }
                var result = await _dbContext.SaveChangesAsync();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public List<CartDetails> GetCarts()
        {
            IQueryable<Cart> resultEntity = null;
            List<CartDetails> finalCart = new List<CartDetails>();
            if (loginStatus != null)
            {
                resultEntity = _dbContext.Carts.Where(x => x.UserId == loginStatus.Id);
                var cartList = resultEntity.ToList();
                foreach (var item in cartList)
                {
                    var itemEntity = _dbContext.Items.FirstOrDefault(x => x.Id == (item.ItemId));
                    finalCart.Add(new CartDetails
                    {
                        DiscountAmount = item.DiscountAmount,
                        MRPAmount = item.MRPAmount,
                        Image = itemEntity.Image,
                        ProductName= itemEntity.Name,
                        Quantity=item.ItemCount
                    });
                }
            }
            return finalCart;
        }

        public async Task<bool> CheckOut()
        {
            if (loginStatus != null)
            {
                IQueryable<Cart> resultEntity = null;
                resultEntity = _dbContext.Carts.Where(x => x.UserId == loginStatus.Id);
                var cartList = resultEntity.ToList();
                foreach (var item in cartList)
                {
                    var itemEntity = _dbContext.Items.FirstOrDefault(x => x.Id == (item.ItemId));
                    _dbContext.Orders.Add(new Orders
                    {
                        UserId = loginStatus.Id,
                        ProductName = itemEntity.Name,
                        Image = itemEntity.Image,
                        Quantity = item.ItemCount,
                        MRPAmount = item.MRPAmount,
                        DiscountAmount = item.DiscountAmount,
                        OrderDate = DateTime.Now
                    });
                    _dbContext.Carts.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Orders> GetOrders()
        {
            if (loginStatus != null)
            {
                return _dbContext.Orders.Where(x => x.UserId == loginStatus.Id).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
