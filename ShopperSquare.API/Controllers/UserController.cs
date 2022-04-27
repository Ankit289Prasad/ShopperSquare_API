﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShopperSquare.API.DTO.Request;
using ShopperSquare.BL;
using ShopperSquare.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSquare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]     //   api/User
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //-----UserRegistration Strats-------

        /// <summary>
        /// API to add a new user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRequest userRequest)
        {
            var user = _mapper.Map<UserBL>(userRequest);
            var registerUser = await _userService.RegisterUser(user);
            if (registerUser)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while adding new user");
            }
        }

        //------Password Reset------

        /// <summary>
        /// API to reset password
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] string[] keyValues)
        {
            var checkStatus = await _userService.ResetPassword(keyValues[0], keyValues[1], keyValues[2]);
            if (checkStatus)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while changing password. Use strong password or Enter valid details");
            }
        }

        //------Login------

        /// <summary>
        /// API to LoginUser
        /// </summary>
        /// <param name="logDetails"></param>
        /// <returns></returns>
        [HttpPost("LoginUser")]
        public async Task<IActionResult> ValidLogin([FromBody]LoginRequest logDetails)
        {
            var user = _mapper.Map<UserLoginBL>(logDetails);
            var loginUser = await _userService.ValidLogin(user);
            if (loginUser)
            {
                return StatusCode(StatusCodes.Status202Accepted);
            }
            else
            {
                return BadRequest("Incorrect UserID or Password");
            }
        }
    }
}
