using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopperSquare.API.DTO;
using ShopperSquare.API.DTO.Request;
using ShopperSquare.API.DTO.Response;
using ShopperSquare.API.Helper;
using ShopperSquare.BL;
using ShopperSquare.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        //private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public ItemController(IItemService itemService,IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        /// <summary>
        /// API to add a new item
        /// </summary>
        /// <param name="itemRequest"></param>
        /// <returns></returns>

        [HttpPost("AddItem")]
        public async Task<ActionResult> AddItem([FromBody] ItemRequest itemRequest)
        {
            var item = _mapper.Map<ItemBL>(itemRequest);
            var addItem = await _itemService.AddItem(item);
            if (addItem)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while adding new item");
            }
        }


        /// <summary>
        /// API to get all items in paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetItems")]
        public ActionResult<List<ItemResponse>> GetItems([FromQuery]PaginationDTO pagination)
        {
            var dbItemsQueryable = _itemService.GetItems();
            HttpContext.InsertPaginationParametersInResponse(dbItemsQueryable, pagination.RecordsPerPage);
            var items = dbItemsQueryable.Paginate(pagination).ToList();
            return _mapper.Map<List<ItemResponse>>(items);
        }

        /// <summary>
        /// API to get all items based on category in paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetItemsBasedOnCategory")]
        public ActionResult<List<ItemResponse>> GetItemsBasedOnCategory([FromQuery] PaginationDTO pagination)
        {
            var dbItemsQueryable = _itemService.GetItemsBasedOnCategory(pagination.CategoryName);
            HttpContext.InsertPaginationParametersInResponse(dbItemsQueryable, pagination.RecordsPerPage);
            var items = dbItemsQueryable.Paginate(pagination).ToList();
            return _mapper.Map<List<ItemResponse>>(items);
        }

        /// <summary>
        /// API to get all items by partial product name in paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetItemsByPartialName")]
        public ActionResult<List<ItemResponse>> GetItemsByPartialName([FromQuery] PaginationDTO pagination)
        {
            var dbItemsQueryable = _itemService.GetItemsByPartialNames(pagination.PartialName);
            HttpContext.InsertPaginationParametersInResponse(dbItemsQueryable, pagination.RecordsPerPage);
            var items = dbItemsQueryable.Paginate(pagination).ToList();
            return _mapper.Map<List<ItemResponse>>(items);
        }

    }
}
