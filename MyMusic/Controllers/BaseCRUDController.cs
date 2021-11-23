using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Controllers
{
    //[Authorize]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service):base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public T Insert([FromBody] TInsert requst)
        {
            return _crudService.Insert(requst);
        }

        [HttpPut("{id}")]
        public T Update(int id, [FromBody] TUpdate requst)
        {
            return _crudService.Update(id, requst);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _crudService.Delete(id);
        }
    }
}
