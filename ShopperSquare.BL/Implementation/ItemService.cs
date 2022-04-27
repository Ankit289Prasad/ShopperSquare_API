using ShopperSquare.BL.Interface;
using ShopperSquare.DL;
using ShopperSquare.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.BL.Implementation
{
    public class ItemService:IItemService
    {
        private readonly IRepo _repo;

        public ItemService(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddItem(ItemBL newItem)
        {
            var newEntity = new Item
            {
                Name=newItem.Name,
                Image=newItem.Image,
                MRPAmount=newItem.MRPAmount,
                InStock=newItem.InStock,
                InventoryId=newItem.InventoryId,
                CategoryId=newItem.CategoryId,
                DiscountPercentage=newItem.DiscountPercentage,
                MaxOrderAmount=newItem.MaxOrderAmount
            };
            //var newEntity = _mapper.Map<User>(newUser);

            return await _repo.AddItem(newEntity);
        }

        public IQueryable<ItemGetBL> GetItems()
        {
            var itemEntity = _repo.GetItems();
            var getList = new List<ItemGetBL>();
            foreach (var item in itemEntity)
            {
                getList.Add(new ItemGetBL{
                    Id=item.Id,
                    Name=item.Name,
                    Image=item.Image,
                    MRPAmount = item.MRPAmount,
                    Discount=item.DiscountPercentage,
                    InStock = item.InStock });
            }
            return getList.AsQueryable();
        }

        public IQueryable<ItemGetBL> GetItemsBasedOnCategory(string categoryName)
        {
            var itemEntity = _repo.GetItemsBasedOnCategory(categoryName);
            var getList = new List<ItemGetBL>();
            foreach (var item in itemEntity)
            {
                getList.Add(new ItemGetBL
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    MRPAmount = item.MRPAmount,
                    Discount = item.DiscountPercentage,
                    InStock = item.InStock
                });
            }
            return getList.AsQueryable();
        }

        public IQueryable<ItemGetBL> GetItemsByPartialNames(string partialName)
        {
            var itemEntity = _repo.GetItemsByPartialNames(partialName);
            var getList = new List<ItemGetBL>();
            foreach (var item in itemEntity)
            {
                getList.Add(new ItemGetBL
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    MRPAmount = item.MRPAmount,
                    Discount = item.DiscountPercentage,
                    InStock = item.InStock
                });
            }
            return getList.AsQueryable();
        }

    }
}
