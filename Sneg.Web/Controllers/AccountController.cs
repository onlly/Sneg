using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Sneg.Common.Enums;
using Sneg.Service.Models;
using Sneg.Web.Attributes;
using Sneg.Web.Authentication;
using Sneg.Web.Models;

namespace Sneg.Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IdentityUserManager _userManager;

        public AccountController(IdentityUserManager userManager)
        {
            _userManager = userManager;
        }
        [ApiAuthorize]
        public IHttpActionResult GetUserInfo()
        {
            var user = CurrentUser;
            return Ok(new UserInfoModel
            {
                Id = user.UserId,
                Name = user.UserName,
                Roles = CurrentUser.Roles
            });
        }

        [ApiAuthorize(RoleEnum.Administrator)]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
            //todo validate
            var user = new UserDto
            {
                UserName = model.LoginName,
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            //todo show normal errors
            if (!result.Succeeded)
                return BadRequest(result.Errors.First());
            return Ok();
        }
    }
}
