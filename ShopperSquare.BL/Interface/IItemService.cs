using ShopperSquare.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.BL.Interface
{
    public interface IItemService
    {
        public Task<bool> AddItem(ItemBL newItem);
        public IQueryable<ItemGetBL> GetItems();
        public IQueryable<ItemGetBL> GetItemsBasedOnCategory(string categoryName);
        public IQueryable<ItemGetBL> GetItemsByPartialNames(string partialName);
    }
}
