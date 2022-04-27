using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        /// <summary>
        /// API to add an item in cart
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>

        [HttpPost("AddItemInCart")]
        public async Task<ActionResult> AddItemInCart(int itemId)
        {
            var addCart = await _cartService.AddItemInCart(itemId);
            if (addCart)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while adding new item to cart");
            }
        }

        /// <summary>
        /// API to remove an item in cart
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>

        [HttpDelete("RemoveItemInCart")]
        public async Task<ActionResult> RemoveItemInCart(int itemId)
        {
            var removeCart = await _cartService.RemoveItemInCart(itemId);
            if (removeCart)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while removing new item to cart");
            }
        }

        /// <summary>
        /// API to fetch all item in cart
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetItemsInCart")]
        public ActionResult<List<CartResponse>> GetItemsInCart([FromQuery] PaginationDTO pagination)
        {
            var dbCartsQueryable = _cartService.GetCarts();
            HttpContext.InsertPaginationParametersInResponse(dbCartsQueryable, pagination.RecordsPerPage);
            var items = dbCartsQueryable.Paginate(pagination).ToList();
            return _mapper.Map<List<CartResponse>>(items);
        }

        /// <summary>
        /// API to checkout all items in cart
        /// </summary>
        /// <returns></returns>
        
        [HttpPost("CheckOut")]
        public async Task<ActionResult> CheckOut()
        {
            var result = await _cartService.CheckOut();
            if(result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Unable to checkout please Login or Try Again");
            }
        }
    }
}
