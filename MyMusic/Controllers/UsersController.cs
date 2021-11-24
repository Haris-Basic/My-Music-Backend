using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Model.Rquests;
using MyMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Model.Users> Get([FromQuery] UsersSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Users GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Users Insert([FromBody]UsersInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Users Update(int id, [FromBody] UsersUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
