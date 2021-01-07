using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProject.Data;
using WebApplicationProject.Data.UnitOfWork;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RoleController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _uow.RoleRepository.GetAll().ToListAsync();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _uow.RoleRepository.GetById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Role/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.RoleID)
            {
                return BadRequest();
            }

            _uow.RoleRepository.Update(role);

            await _uow.Save();

            return NoContent();
        }

        // POST: api/Role
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            _uow.RoleRepository.Create(role);
            await _uow.Save();

            return CreatedAtAction("GetRole", new { id = role.RoleID }, role);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var role = await _uow.RoleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }

            _uow.RoleRepository.Delete(role);
            await _uow.Save();

            return role;
        }

    }
}
