using Microsoft.AspNetCore.Mvc;
using MyMusic.Model.Rquests;
using MyMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Controllers
{
    public class CategoryController : BaseCRUDController<Model.Category,Model.CategorySearchObj, CategoryInsertRequest,CategoryUbdateRequest>
    {
        public CategoryController(ICategoryService service) : base(service)
        {

        }
    }
}
