using MyMusic.Model.Rquests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public interface ICategoryService : ICRUDService<Model.Category,Model.CategorySearchObj,CategoryInsertRequest,CategoryUbdateRequest>
    {
    }
}
