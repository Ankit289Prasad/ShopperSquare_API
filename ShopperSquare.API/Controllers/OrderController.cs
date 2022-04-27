using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopperSquare.API.DTO;
using ShopperSquare.API.DTO.Response;
using ShopperSquare.API.Helper;
using ShopperSquare.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// API to get all order history
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("GetAllOrder")]
        public ActionResult<List<OrderResponse>> GetAllOrder(PaginationDTO pagination)
        {
            var dbOrderQueryable = _orderService.GetAllOrder();
            HttpContext.InsertPaginationParametersInResponse(dbOrderQueryable, pagination.RecordsPerPage);
            var orders = dbOrderQueryable.Paginate(pagination).ToList();
            return _mapper.Map<List<OrderResponse>>(orders);
        }
    }
}
