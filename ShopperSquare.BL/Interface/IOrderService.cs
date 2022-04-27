using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopperSquare.BL.Interface
{
    public interface IOrderService
    {
        public IQueryable<OrderGetBL> GetAllOrder();
    }
}
