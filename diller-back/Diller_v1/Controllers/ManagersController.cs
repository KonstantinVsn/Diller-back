using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diller.Models;
using Diller.Data;
using System.Net.Http;
using Diller.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Diller.Models.Helpers;

namespace Diller.Controllers
{
    [Produces("application/json")]
    [Route("api/Managers")]
    public class ManagersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _appDbContext;

        public ManagersController(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        // GET: api/Managers
        [HttpGet]
        public IEnumerable<PersonViewModel> GetManager()
        {
            var results = _appDbContext.Persons.ToList();
            var result = _appDbContext.Persons.Where(x => x.Identity.Role == "Manager").Select(p => new PersonViewModel()
            {
                Email = p.Identity.Email,
                Id = p.Id,
                FirstName = p.Identity.FirstName,
                LastName = p.Identity.LastName,
                Role = p.Identity.Role,
                PhoneNumber = p.Identity.PhoneNumber
            }).ToList();
            return result;
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manager = await _appDbContext.Persons.SingleOrDefaultAsync(m => m.Id == id);

            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        // PUT: api/Managers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager([FromRoute] int id, [FromBody] Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manager.Id)
            {
                return BadRequest();
            }
            //var baseManager = _appDbContext.Persons.Where(x => x.Id == manager.Id).FirstOrDefault();
            var baseManager = _appDbContext.Persons.Where(x => x.Id == manager.Id).Include(c => c.Identity).FirstOrDefault();
            baseManager.Identity.Email = manager.Email;
            baseManager.Identity.PhoneNumber = manager.PhoneNumber;
            baseManager.Identity.Role = manager.Role;
            baseManager.Identity.FirstName = manager.FirstName;
            baseManager.Identity.LastName = manager.LastName;

            try
            {
                var result = await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

            return new JsonResult("Manager updated!");
        }

        // POST: api/Managers
        [HttpPost]
        public async Task<IActionResult> PostManager([FromBody] Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(manager);
            userIdentity.Id = null;
            userIdentity.Role = "Manager";
            var result = await _userManager.CreateAsync(userIdentity, "12345678");

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Persons.AddAsync(new Person { IdentityId = userIdentity.Id });
            await _appDbContext.SaveChangesAsync();

            return new JsonResult("Manager created!");

            //return CreatedAtAction("GetManager", new { id = manager.Id }, manager);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manager = await _appDbContext.Persons.SingleOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            _appDbContext.Persons.Remove(manager);
            await _appDbContext.SaveChangesAsync();

            return Ok(manager);
        }

        private bool ManagerExists(int id)
        {
            return _appDbContext.Persons.Any(e => e.Id == id);
        }
    }
}