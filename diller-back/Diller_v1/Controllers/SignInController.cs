using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Diller.Data;
using Diller.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Diller.Models;
using Diller.Models.Helpers;

namespace Diller.Controllers
{
    [Produces("application/json")]
    [Route("api/signin")]
    public class SignInController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public SignInController(IMapper mapper, UserManager<AppUser> userManager, ApplicationDbContext appDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Persons.AddAsync(new Person { IdentityId = userIdentity.Id});
            await _appDbContext.SaveChangesAsync();

            return new JsonResult("User created!");
        }
    }
}