using AutoMapper;
using MyMusic.Database;
using MyMusic.Model.Rquests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class CategoryService : BaseCRUDService<Model.Category,Database.Category,Model.CategorySearchObj,CategoryInsertRequest,CategoryUbdateRequest> ,ICategoryService
    {
        public CategoryService(MyMusicContext db, IMapper mapper): base(db,mapper)
        {
        }

        public override IEnumerable<Model.Category> Get(Model.CategorySearchObj search = null)
        {
            var entity = Context.Set<Database.Category>().AsQueryable(); // da bi mogli unutar if izraza pisati query

            if (!string.IsNullOrEmpty(search.CategoryName))
            {
                entity = entity.Where(x => x.CategoryName.Contains(search.CategoryName));
            }

            var list = entity.ToList();

            return _mapper.Map<IEnumerable<Model.Category>>(list);
        }
    }
}
