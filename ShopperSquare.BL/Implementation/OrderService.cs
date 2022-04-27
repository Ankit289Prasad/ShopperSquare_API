using ShopperSquare.BL.Interface;
using ShopperSquare.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopperSquare.BL.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepo _repo;

        public OrderService(IRepo repo)
        {
            _repo = repo;
        }

        public IQueryable<OrderGetBL> GetAllOrder()
        {
            var orderEntity = _repo.GetOrders();
            if (orderEntity != null)
            {
                var getList = new List<OrderGetBL>();
                if (orderEntity != null)
                {
                    foreach (var item in orderEntity)
                    {
                        getList.Add(new OrderGetBL
                        {
                            OrderId=item.OrderId,
                            ProductName=item.ProductName,
                            Quantity=item.Quantity,
                            MRPAmount=item.MRPAmount,
                            DiscountAmount=item.DiscountAmount,
                            Image=item.Image,
                            OrderDate=item.OrderDate
                        });
                    }
                }
                return getList.AsQueryable();
            }
            else
            {
                return (new List<OrderGetBL>()).AsQueryable();
            }
        }
    }
}
