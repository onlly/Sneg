using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sneg.Common.Enums;
using Sneg.Service.Interfaces;
using Sneg.Web.Attributes;

namespace Sneg.Web.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ApiAuthorize(RoleEnum.Administrator)]
        public IHttpActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }
    }
}
